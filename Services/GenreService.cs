using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services
{
    public class GenreService
    {
        private ozoneprimeContext database;

        public GenreService(ozoneprimeContext database)
        {
            this.database = database;
        }

        public void Create(Genre genre)
        {
            List<Genre> genres = database.Genres.ToList();
            if (!genres.Exists(g => g.Name == genre.Name))
            {
                database.Add(genre);
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
