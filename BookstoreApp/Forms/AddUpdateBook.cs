using BookstoreApp.Database;
using BookstoreApp.Models;
using System;
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
        private Button btnSave;

        public AddUpdateBook(Book? book = null)
        {
            InitializeComponent();
            _isUpdate = book != null;
            _book = book;
            SetupForm();
        }

        private void SetupForm()
        {
            Text = _isUpdate ? "Update Book" : "Add Book";
            txtTitle = new TextBox { Left = 20, Top = 20, Width = 200, Text = string.Empty, PlaceholderText = "Title" };
            txtPrice = new TextBox { Left = 20, Top = 60, Width = 200, Text = string.Empty, PlaceholderText = "Price" };
            txtISBN = new TextBox { Left = 20, Top = 100, Width = 200, Text = string.Empty, PlaceholderText = "ISBN (13 digits)" };

            if (_book != null)
            {
                txtTitle.Text = _book.Title;
                txtPrice.Text = _book.Price.ToString();
                txtISBN.Text = _book.ISBN;
            }

            btnSave = new Button { Left = 20, Top = 140, Width = 200, Text = "Save" };
            btnSave.Click += BtnSave_Click;
            Controls.Add(txtTitle);
            Controls.Add(txtPrice);
            Controls.Add(txtISBN);
            Controls.Add(btnSave);
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
            if (_isUpdate)
                await BookDb.UpdateAsync(_book);
            else
                await BookDb.AddAsync(_book);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void InitializeComponent()
        {
            ClientSize = new Size(250, 200);
            Text = "Book";
        }
    }
}
