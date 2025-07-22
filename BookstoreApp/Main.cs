using BookstoreApp.Database;
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
    }
}
