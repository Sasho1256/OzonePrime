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

        internal void Create(Film film)
        { 
            database.Films.Add(film);
            database.SaveChanges();
        }

        /*
        public void AddFilm(Film film)
        {
            database.Films.Add(film);
        }

        public void EditFilm(int id, Film film)
        {
            Film filmToEdit = database.Films.FirstOrDefault(x => x.Id == id);
            filmToEdit = film;
        }

        public void RemoveFilm(int id)
        {
            Film filmToRemove = database.Films.FirstOrDefault(x => x.Id == id);
            database.Films.Remove(filmToRemove);
        }
        */
    }
}
