using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace OzonePrime.Models
{
    public partial class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? YearRelease { get; set; }
        public int ExpirationDays { get; set; }
        [ForeignKey("Director")]
        [Column("director_id")]
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        [ForeignKey("Genre")]
        [Column("genre_id")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
