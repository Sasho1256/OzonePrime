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
        private ozoneprimeContext database;

        public FilmService(ozoneprimeContext database)
        {
            this.database = database;
        }

        public List<Film> GetAllFilms()
        {
            return database.Films.ToList();
        }
        public List<Film> FilmInfo()
        {
            return database.Films.ToList();
        }

        internal void Create(Film film)
        { 
            database.Films.Add(film);
            database.SaveChanges();
        }
    }
}
