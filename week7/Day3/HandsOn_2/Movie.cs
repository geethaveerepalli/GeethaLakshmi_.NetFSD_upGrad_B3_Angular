using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCatalogApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public string Rating { get; set; }
    }
}