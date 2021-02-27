using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzonePrime.Database;
using OzonePrime.Models;

namespace OzonePrime.Services
{
    public class FilmService
    {
        private InMemoryDatabase database;

        public FilmService(InMemoryDatabase database)
        {
            this.database = database;
        }

        public List<Film> GetAllFilms()
        {
            return database.Films;
        }

        internal void Create(Film film)
        {
            film.Id = database.Count;
            database.Count++;
            database.Films.Add(film);
        }
    }
}
