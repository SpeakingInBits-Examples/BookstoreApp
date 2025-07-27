using BookstoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Database;

public class BookStoreDb : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookstoreDb;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Genre>().HasData(
            new Genre { GenreId = 1, Name = "Fiction" },
            new Genre { GenreId = 2, Name = "Non-Fiction" },
            new Genre { GenreId = 3, Name = "Science Fiction" },
            new Genre { GenreId = 4, Name = "Fantasy" },
            new Genre { GenreId = 5, Name = "Mystery" },
            new Genre { GenreId = 6, Name = "Biography" },
            new Genre { GenreId = 7, Name = "Romance" },
            new Genre { GenreId = 8, Name = "Historical" },
            new Genre { GenreId = 9, Name = "Horror" },
            new Genre { GenreId = 10, Name = "Young Adult" }
        );
    }

    // Add entities to track in the database as DbSets below

    public DbSet<Book> Books { get; set; }

    public DbSet<Genre> Genres { get; set; }
}