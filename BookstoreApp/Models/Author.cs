using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models;

/// <summary>
/// Represents an individual Author of a Book
/// </summary>
public class Author
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// The first and last name, in that order separated by a space, 
    /// for the Author
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The books the author is listed on
    /// </summary>
    public List<Book> Books { get; set; } = [];
}
