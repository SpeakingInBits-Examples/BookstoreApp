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
    public partial class ManageAuthorsForm : Form
    {
        private ListBox lstAuthors;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private List<Author> _authors = new();

        public ManageAuthorsForm()
        {
            InitializeComponent();
            SetupForm();
            LoadAuthorsAsync();
        }

        private void SetupForm()
        {
            Text = "Manage Authors";
            Width = 400;
            Height = 400;
            lstAuthors = new ListBox { Left = 20, Top = 20, Width = 240, Height = 300 };
            btnAdd = new Button { Left = 280, Top = 20, Width = 90, Text = "Add" };
            btnUpdate = new Button { Left = 280, Top = 60, Width = 90, Text = "Update" };
            btnDelete = new Button { Left = 280, Top = 100, Width = 90, Text = "Delete" };
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            Controls.Add(lstAuthors);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
        }

        private async void LoadAuthorsAsync()
        {
            using BookStoreDb db = new();
            _authors = await db.Authors.OrderBy(a => a.Name).ToListAsync();
            lstAuthors.DataSource = null;
            lstAuthors.DataSource = _authors;
            lstAuthors.DisplayMember = nameof(Author.Name);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddUpdateAuthorForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAuthorsAsync();
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (lstAuthors.SelectedItem is Author author)
            {
                using (var form = new AddUpdateAuthorForm(author))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAuthorsAsync();
                    }
                }
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstAuthors.SelectedItem is Author author)
            {
                var confirm = MessageBox.Show($"Delete author '{author.Name}'?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using var db = new BookstoreApp.Database.BookStoreDb();
                    db.Remove(author);
                    await db.SaveChangesAsync();
                    LoadAuthorsAsync();
                }
            }
        }

        private void InitializeComponent() { }
    }
}
