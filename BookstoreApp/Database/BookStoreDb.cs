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

    // Add entities to track in the database as DbSets below

    public DbSet<Book> Books { get; set; }
}