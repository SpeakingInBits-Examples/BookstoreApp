using BookstoreApp.Models;
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
    /// Asynchronously retrieves a book from the database by its title.
    /// </summary>
    /// <param name="title">The title of the book to search for. Cannot be null or empty.</param>
    /// <returns>A <see cref="Book"/> object representing the book with the specified title, or <see langword="null"/> if no such
    /// book is found.</returns>
    public static async Task<Book?> GetBookByTitleAsync(string title)
    {
        using BookStoreDb db = new();

        Book? book = await db.Books.Where(b => title == b.Title).FirstOrDefaultAsync();

        return book;
    }

    /// <summary>
    /// Asynchronously adds a new book to the database.
    /// </summary>
    /// <param name="book">The book to be added. Cannot be null.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task AddAsync(Book book)
    {
        using BookStoreDb db = new();

        // Add the book to the context first
        db.Books.Add(book);

        // Mark each genre as unchanged so EF does not try to add them
        foreach (var genre in book.Genres)
        {
            db.Entry(genre).State = EntityState.Unchanged;
        }
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

        // Attach the book entity first
        db.Books.Update(book);

        // Mark each genre as unchanged so EF does not try to add or update them
        foreach (var genre in book.Genres)
        {
            db.Entry(genre).State = EntityState.Unchanged;
        }
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

        Book? bookToDelete = await db.Books.FindAsync(id);
        if (bookToDelete != null)
        {
            db.Books.Remove(bookToDelete);
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
