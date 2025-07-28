using BookstoreApp.Database;
using BookstoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreApp.Forms
{
    public partial class AddUpdateBook : Form
    {
        private Book? _book;
        private bool _isUpdate;
        private TextBox txtTitle;
        private TextBox txtPrice;
        private TextBox txtISBN;
        private TextBox txtDescription;
        private CheckedListBox clbGenres;
        private Button btnSave;
        private List<Genre> _genres = new();

        public AddUpdateBook(Book? book = null)
        {
            InitializeComponent();
            _isUpdate = book != null;
            _book = book;
            SetupForm();
            LoadGenresAsync();
        }

        private void SetupForm()
        {
            Text = _isUpdate ? "Update Book" : "Add Book";
            txtTitle = new TextBox { Left = 20, Top = 20, Width = 200, Text = string.Empty, PlaceholderText = "Title" };
            txtPrice = new TextBox { Left = 20, Top = 60, Width = 200, Text = string.Empty, PlaceholderText = "Price" };
            txtISBN = new TextBox { Left = 20, Top = 100, Width = 200, Text = string.Empty, PlaceholderText = "ISBN (13 digits)" };
            txtDescription = new TextBox { Left = 20, Top = 140, Width = 200, Height = 60, Multiline = true, PlaceholderText = "Description" };
            clbGenres = new CheckedListBox { Left = 20, Top = 210, Width = 200, Height = 80 };

            if (_book != null)
            {
                txtTitle.Text = _book.Title;
                txtPrice.Text = _book.Price.ToString();
                txtISBN.Text = _book.ISBN;
                txtDescription.Text = _book.Description ?? string.Empty;
            }

            btnSave = new Button { Left = 20, Top = 300, Width = 200, Text = "Save" };
            btnSave.Click += BtnSave_Click;
            Controls.Add(txtTitle);
            Controls.Add(txtPrice);
            Controls.Add(txtISBN);
            Controls.Add(txtDescription);
            Controls.Add(clbGenres);
            Controls.Add(btnSave);
        }

        private async void LoadGenresAsync()
        {
            using var db = new BookStoreDb();
            _genres = await db.Genres.OrderBy(g => g.Name).ToListAsync();
            clbGenres.Items.Clear();
            foreach (var genre in _genres)
            {
                int idx = clbGenres.Items.Add(genre);
                // Check the genre if the book already has it
                if (_book != null && _book.Genres.Any(g => g.GenreId == genre.GenreId))
                {
                    clbGenres.SetItemChecked(idx, true);
                }
            }
            clbGenres.DisplayMember = nameof(Genre.Name);
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (_book is null)
            {
                string isbn = txtISBN.Text.Trim();
                if (isbn.Length != 13 || !long.TryParse(isbn, out _))
                {
                    MessageBox.Show("ISBN must be exactly 13 digits (numbers only).");
                    return;
                }
                _book = new Book { Title = txtTitle.Text, ISBN = isbn };
            }
            else
            {
                _book.Title = txtTitle.Text;
                string isbn = txtISBN.Text.Trim();
                if (isbn.Length != 13 || !long.TryParse(isbn, out _))
                {
                    MessageBox.Show("ISBN must be exactly 13 digits (numbers only).");
                    return;
                }
                _book.ISBN = isbn;
            }
            if (double.TryParse(txtPrice.Text, out double price))
                _book.Price = price;
            else
            {
                MessageBox.Show("Invalid price.");
                return;
            }
            _book.Description = txtDescription.Text;
            var selectedGenres = new List<Genre>();
            foreach (var item in clbGenres.CheckedItems)
            {
                if (item is Genre genre)
                    selectedGenres.Add(genre);
            }
            _book.Genres = selectedGenres;
            if (_isUpdate)
                await BookDb.UpdateAsync(_book);
            else
                await BookDb.AddAsync(_book);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void InitializeComponent()
        {
            ClientSize = new System.Drawing.Size(250, 350);
            Text = "Book";
        }
    }
}
