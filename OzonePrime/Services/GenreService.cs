using OzonePrime.Models;
using OzonePrime.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services
{
    public class GenreService : IGenreService
    {
        private ozoneprimeContext database;

        public GenreService(ozoneprimeContext database)
        {
            this.database = database;
        }

        public void Create(Genre genre)
        {
            if (string.IsNullOrEmpty(genre.Name) || string.IsNullOrWhiteSpace(genre.Name))
            {
                throw new ArgumentException("Incorrect input for name.");
            }
            List<Genre> genres = database.Genres.ToList();
            if (!genres.Exists(g => g.Name == genre.Name))
            {
                database.Genres.Add(genre);
            }
            database.SaveChanges();
        }

        public List<Genre> GetAll()
        {
            List<Genre> genres = database.Genres.ToList();
            return genres;
        }
    }
}
