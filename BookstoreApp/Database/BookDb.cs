using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Database
{
    /// <summary>
    /// Provides methods for Book CRUD functionality
    /// </summary>
    public static class BookDb
    {
        /// <summary>
        /// Retrieves a list of books from the database
        /// sorted in alphabetical order by Title (A - Z)
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Book>> GetBooksAsync()
        {
            using BookStoreDb db = new();

            // Get all books from the database
            List<Book> books = await db.Books.OrderBy(b => b.Title).ToListAsync(); // EF Core method syntax

            return books;
        }
    }
}
