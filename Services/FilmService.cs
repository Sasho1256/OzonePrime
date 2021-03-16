using System;
using System.Collections.Generic;
using System.Data;
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
        public Film FilmInfo(Film film)
        {
            film.Genre = database.Genres.FirstOrDefault(g => g.Id == film.GenreId);
            film.Director = database.Directors.FirstOrDefault(d => d.Id == film.DirectorId);

            return film;
        }
        public Film FilmInfoInMyList(Film film)
        {
            film.Genre = database.Genres.FirstOrDefault(g => g.Id == film.GenreId);
            film.Director = database.Directors.FirstOrDefault(d => d.Id == film.DirectorId);

            return film;
        }

        internal void Create(Film film)
        {
            if (string.IsNullOrWhiteSpace(film.Name) || string.IsNullOrEmpty(film.Name))
            {
                throw new ArgumentException("Invalid input for name.");
            }            
            if (string.IsNullOrWhiteSpace(film.Description) || string.IsNullOrEmpty(film.Description))
            {
                throw new ArgumentException("Invalid input for description.");
            }            

            database.Films.Add(film);
            database.SaveChanges();
        }

        internal void Edit(Film updatedFilm, string filmId)
        {
            Film film = GetById(filmId);

            if (string.IsNullOrWhiteSpace(updatedFilm.Name) || string.IsNullOrEmpty(updatedFilm.Name))
            {
                throw new ArgumentException("Invalid input for name.");
            }            
            if (string.IsNullOrWhiteSpace(updatedFilm.Description) || string.IsNullOrEmpty(updatedFilm.Description))
            {
                throw new ArgumentException("Invalid input for description.");
            }

            film.Name = updatedFilm.Name;
            film.Price = updatedFilm.Price;
            film.Description = updatedFilm.Description;
            film.YearRelease = updatedFilm.YearRelease;
            film.DirectorId = updatedFilm.DirectorId;
            film.GenreId = updatedFilm.GenreId;

            database.Films.Update(film);
            database.SaveChanges();
        }

        public void Delete(string filmId)
        {
            Film filmToDelete = GetById(filmId);
            List<FilmsUser> filmsUsersToDelete = database.FilmsUsers.Where(fu => fu.FilmId == filmToDelete.Id).ToList();

            database.FilmsUsers.RemoveRange(filmsUsersToDelete);
            database.Films.Remove(filmToDelete);
            database.SaveChanges();
        }

        public Film GetById(string filmId)
        {
            Film film = database.Films.FirstOrDefault(f => f.Id == int.Parse(filmId));
            return film;
        }
    }
}
