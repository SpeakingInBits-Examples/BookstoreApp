using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Database;

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

    /// <summary>
    /// Asynchronously adds a new book to the database.
    /// </summary>
    /// <param name="book">The book to be added. Cannot be null.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task AddAsync(Book book)
    {
        using BookStoreDb db = new();

        db.Books.Add(book);
        await db.SaveChangesAsync();
    }

    /// <summary>
    /// Asynchronously updates the specified book in the database.
    /// </summary>
    /// <param name="book">The book entity to update. Must not be <see langword="null"/>.</param>
    /// <returns>A task that represents the asynchronous update operation.</returns>
    public static async Task UpdateAsync(Book book)
    {
        using BookStoreDb db = new();

        db.Books.Update(book);
        await db.SaveChangesAsync();
    }

    /// <summary>
    /// Asynchronously deletes a book from the database by its identifier.
    /// </summary>
    /// <remarks>If the book with the specified <paramref name="id"/> does not exist, no action is
    /// taken.</remarks>
    /// <param name="id">The unique identifier of the book to be deleted. Must be a valid book ID.</param>
    /// <returns>A task that represents the asynchronous delete operation.</returns>
    public static async Task DeleteAsync(int id)
    {
        using BookStoreDb db = new();

        Book? b = await db.Books.FindAsync(id);
        if (b != null)
        {
            db.Books.Remove(b);
            await db.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Asynchronously deletes the specified book from the database.
    /// </summary>
    /// <param name="book">The book to be deleted. Must not be null.</param>
    /// <returns>A task that represents the asynchronous delete operation.</returns>
    public static async Task DeleteAsync(Book book)
    {
        using BookStoreDb db = new();
        db.Books.Remove(book);
        await db.SaveChangesAsync();
    }
}
