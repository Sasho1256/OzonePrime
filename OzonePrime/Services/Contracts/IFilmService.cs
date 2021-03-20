using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services.Contracts
{
    interface IFilmService
    {
        /// <summary>
        /// Returns a list with all the films in the database.
        /// </summary>
        /// <returns></returns>
        List<Film> GetAllFilms();
        
        /// <summary>
        /// Sets the director and genre of a <paramref name="film"/> and returns the updated <paramref name="film"/>.
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        Film FilmInfo(Film film);

        /// <summary>
        /// Sets the director and genre of <paramref name="film"/> and returns the updated <paramref name="film"/>.
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        Film FilmInfoInMyList(Film film);

        /// <summary>
        /// Adds <paramref name="film"/> to the database.
        /// </summary>
        /// <param name="film"></param>
        void Create(Film film);
        
        /// <summary>
        /// Updates the film, that has the same id as <paramref name="filmId"/>, with the info in <paramref name="updatedFilm"/>.
        /// </summary>
        /// <param name="updatedFilm"></param>
        /// <param name="filmId"></param>
        void Edit(Film updatedFilm, string filmId);

        /// <summary>
        /// Deletes the film, that has the same id as <paramref name="filmId"/>, from the database.
        /// </summary>
        /// <param name="filmId"></param>
        void Delete(string filmId);

        /// <summary>
        /// Deletes the film, that has the same id as <paramref name="filmId"/>.
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns></returns>
        Film GetById(string filmId);
    }
}
