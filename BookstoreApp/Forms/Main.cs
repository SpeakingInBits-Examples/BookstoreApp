using BookstoreApp.Database;
using BookstoreApp.Forms;
using BookstoreApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            btnAddUpdate.Click += BtnAddUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            button1.Click += BtnAddAuthor_Click;
            button2.Click += BtnUpdateAuthor_Click;
            button3.Click += BtnDeleteAuthor_Click;
            LoadBooksAsync();
        }

        private async void LoadBooksAsync()
        {
            lstBooks.Items.Clear();
            List<Book> books = await BookDb.GetBooksAsync();
            foreach (Book book in books)
            {
                lstBooks.Items.Add(book);
            }
        }

        private void BtnAddUpdate_Click(object sender, EventArgs e)
        {
            Book selectedBook = lstBooks.SelectedItem as Book;
            using (var form = new AddUpdateBook(selectedBook))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooksAsync();
                }
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            Book selectedBook = lstBooks.SelectedItem as Book;
            if (selectedBook != null)
            {
                await BookDb.DeleteAsync(selectedBook.Id);
                LoadBooksAsync();
            }
        }

        // Author management event handlers
        private void BtnAddAuthor_Click(object sender, EventArgs e)
        {
            using (var form = new ManageAuthorsForm())
            {
                form.ShowDialog();
            }
        }
        private void BtnUpdateAuthor_Click(object sender, EventArgs e)
        {
            using (var form = new ManageAuthorsForm())
            {
                form.ShowDialog();
            }
        }
        private void BtnDeleteAuthor_Click(object sender, EventArgs e)
        {
            using (var form = new ManageAuthorsForm())
            {
                form.ShowDialog();
            }
        }
    }
}
