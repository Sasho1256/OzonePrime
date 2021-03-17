using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Interfaces.IModels
{
    interface IFilm
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
        public IDirector Director { get; set; }
        [ForeignKey("Genre")]
        [Column("genre_id")]
        public int GenreId { get; set; }
        public IGenre Genre { get; set; }
    }
}
