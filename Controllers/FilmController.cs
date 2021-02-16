using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonePrime.Models;

namespace OzonePrime.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index(Film film)
        {
            return View(film);
        }

        [HttpPost]
        public IActionResult IndexPost(DirectorDTO dto)
        {
            Film film = new Film();

            film.Title = "Film Title";
            film.YearRelease = 2021;
            film.Directors.AddRange(new List<string>() { $"{dto.FirstName} {dto.LastName}", "Director2" });

            return RedirectToAction("Index", film);
        }
    }
}