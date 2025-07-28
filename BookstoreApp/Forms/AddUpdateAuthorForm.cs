using BookstoreApp.Models;
using System;
using System.Windows.Forms;

namespace BookstoreApp.Forms
{
    public partial class AddUpdateAuthorForm : Form
    {
        private TextBox txtName;
        private Button btnSave;
        private Author? _author;
        private bool _isUpdate;

        public AddUpdateAuthorForm(Author? author = null)
        {
            InitializeComponent();
            _author = author;
            _isUpdate = author != null;
            SetupForm();
        }

        private void SetupForm()
        {
            Text = _isUpdate ? "Update Author" : "Add Author";
            Width = 300;
            Height = 150;
            txtName = new TextBox { Left = 20, Top = 20, Width = 240, PlaceholderText = "Author Name" };
            btnSave = new Button { Left = 20, Top = 60, Width = 240, Text = "Save" };
            btnSave.Click += BtnSave_Click;
            Controls.Add(txtName);
            Controls.Add(btnSave);
            if (_isUpdate && _author != null)
            {
                txtName.Text = _author.Name;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name is required.");
                return;
            }
            using var db = new BookstoreApp.Database.BookStoreDb();
            if (_isUpdate && _author != null)
            {
                var author = await db.Authors.FindAsync(_author.Id);
                if (author != null)
                {
                    author.Name = name;
                    await db.SaveChangesAsync();
                }
            }
            else
            {
                db.Authors.Add(new Author { Name = name });
                await db.SaveChangesAsync();
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void InitializeComponent() { }
    }
}
