using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models
{
    /// <summary>
    /// Represents an individual book for sale
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The primary key/unique identifier for the book
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The title of the book
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Sales price of the book
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The 13 digit ISBN number. No dashes allowed, digits only
        /// </summary>
        public required string ISBN { get; set; }

        /// <summary>
        /// The optional user facing description of the book.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the list of genres associated with the item.
        /// </summary>
        public List<Genre> Genres { get; set; } = [];

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public required Author BookAuthor { get; set; }

        /// <summary>
        /// Displays book information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Title} - {Price:c2}";
        }
    }
}
