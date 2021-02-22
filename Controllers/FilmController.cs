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

        public FilmController(FilmService filmService)
        {
            this.filmService = filmService;
        }
        public IActionResult GetAllFilms()
        {
            List<Film> films = this.filmService.GetAllFilms();
            return View(films);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Film film)
        {
            this.filmService.Create(film);
            return RedirectToAction(nameof(GetAllFilms));
        }
    }
}