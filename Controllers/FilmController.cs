using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonePrime.Models;
using OzonePrime.Services;

namespace OzonePrime.Controllers
{
    public class FilmController : Controller
    {
        private FilmService filmService;
        private GenreService genreService;
        DirectorService directorService;

        public FilmController(FilmService filmService, GenreService genreService, DirectorService directorService)
        {
            this.filmService = filmService;
            this.genreService = genreService;
            this.directorService = directorService;
        }
        public IActionResult GetAllFilms()
        {
            List<Film> films = this.filmService.GetAllFilms();
            return View(films);
        }
        public IActionResult FilmInfo(Film film)
        {
            return View(film);
        }

        [HttpGet]
        public IActionResult Create()
        {
            DirectorsGenresDTO dg = new DirectorsGenresDTO(this.directorService.GetAll(), this.genreService.GetAll());

            //ViewData.Add("Directors", this.directorService.GetAll());
            //ViewData.Add("Genres", this.genreService.GetAll());          
            return View(dg);
        }
        [HttpPost]
        public IActionResult Create(Film film)
        {
            this.filmService.Create(film);
            return RedirectToAction(nameof(GetAllFilms));
        }
    }
}