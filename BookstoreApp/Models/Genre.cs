using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models
{
    /// <summary>
    /// Represents a genre category for books
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Primary key for the Genre
        /// </summary>
        [Key]
        public int GenreId { get; set; }

        /// <summary>
        /// The name of the Genre
        /// </summary>
        public required string Name { get; set; }
    }
}
