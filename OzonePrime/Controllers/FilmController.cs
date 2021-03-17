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
        private DirectorService directorService;
        private UserService userService;

        public FilmController(FilmService filmService, GenreService genreService, DirectorService directorService, UserService userService)
        {
            this.filmService = filmService;
            this.genreService = genreService;
            this.directorService = directorService;
            this.userService = userService;
        }
        
        public IActionResult GetAllFilms()
        {
            List<Film> films = this.filmService.GetAllFilms();
            return View(films);
        }
        
        public IActionResult FilmInfo(Film film)
        {
            film = filmService.FilmInfo(film);
            return View(film);
        }

        public IActionResult FilmInfoInMyList(Film film)
        {
            film = filmService.FilmInfoInMyList(film);
            return View(film);
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                userService.CheckIfThereIsALoggedUser();
            }
            catch (AccessViolationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }

            FilmDTO dg = new FilmDTO(this.directorService.GetAll(), this.genreService.GetAll());
            //ViewData.Add("Directors", this.directorService.GetAll());
            //ViewData.Add("Genres", this.genreService.GetAll());          
            return View(dg);
        }
        [HttpPost]
        public IActionResult Create(Film film)
        {
            try
            {
                this.filmService.Create(film);
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }

            return RedirectToAction(nameof(GetAllFilms));
        }

        [HttpGet]
        public IActionResult Edit(string filmId)
        {
            try
            {
                userService.CheckIfThereIsALoggedUser();
            }
            catch (AccessViolationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }

            Film film = this.filmService.GetById(filmId);
            FilmDTO fdg = new FilmDTO(film, this.directorService.GetAll(), this.genreService.GetAll());
            
            return View(fdg);
        }
        [HttpPost]
        public IActionResult Edit(Film film, string filmId)
        {
            try
            {
                this.filmService.Edit(film, filmId);
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }

            return RedirectToAction(nameof(GetAllFilms));
        }

        [HttpPost]
        public IActionResult Delete(string filmId)
        {
            try
            {
                userService.CheckIfThereIsALoggedUser();
            }
            catch (AccessViolationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }

            filmService.Delete(filmId);
            return RedirectToAction("GetAllFilms");
        }
    }
}