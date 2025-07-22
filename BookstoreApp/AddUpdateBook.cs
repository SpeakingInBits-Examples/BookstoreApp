using BookstoreApp.Database;
using System;
using System.Windows.Forms;

namespace BookstoreApp
{
    public partial class AddUpdateBook : Form
    {
        private Book? _book;
        private bool _isUpdate;
        private TextBox txtTitle;
        private TextBox txtPrice;
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
            this.Text = _isUpdate ? "Update Book" : "Add Book";
            txtTitle = new TextBox { Left = 20, Top = 20, Width = 200, Text = string.Empty, PlaceholderText = "Title" };
            txtPrice = new TextBox { Left = 20, Top = 60, Width = 200, Text = string.Empty, PlaceholderText = "Price" };

            if (_book != null)
            {
                txtTitle.Text = _book.Title;
                txtPrice.Text = _book.Price.ToString();
            }

            btnSave = new Button { Left = 20, Top = 100, Width = 200, Text = "Save" };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(txtTitle);
            this.Controls.Add(txtPrice);
            this.Controls.Add(btnSave);
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (_book is null)
            {
                _book = new() { Title = txtTitle.Text };
            }
            else
            {
                _book.Title = txtTitle.Text;
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.ClientSize = new System.Drawing.Size(250, 150);
            this.Text = "Book";
        }
    }
}
