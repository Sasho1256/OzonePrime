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
        //public Film FilmInfo(Film film)
        //{
            //return database.Films.FirstOrDefault(f=>f.Id == (film));
        //}

        internal void Create(Film film)
        { 
            database.Films.Add(film);
            database.SaveChanges();
        }
    }
}
