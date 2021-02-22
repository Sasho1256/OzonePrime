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
        public List<Film> GetAllFilms()
        {
            return InMemoryDatabase.Films;
        }

        internal void Create(Film film)
        {
            film.Id = InMemoryDatabase.Count;
            InMemoryDatabase.Count++;
            InMemoryDatabase.Films.Add(film);
        }
    }
}
