using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services.Contracts
{
    interface IFilmService
    {
        List<Film> GetAllFilms();
        Film FilmInfo(Film film);
        Film FilmInfoInMyList(Film film);
        void Create(Film film);
        void Edit(Film updatedFilm, string filmId);
        void Delete(string filmId);
        Film GetById(string filmId);
    }
}
