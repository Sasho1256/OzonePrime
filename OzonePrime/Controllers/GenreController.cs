using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Controllers
{
    public class GenreController : Controller
    {
        private GenreService genreService;
        private UserService userService;

        public GenreController(GenreService genreService, UserService userService)
        {
            this.genreService = genreService;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                userService.CheckIfThereIsALoggedUser();
            }
            catch (AccessViolationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            try
            {
                genreService.Create(genre);
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            return RedirectToAction("Create");
        }        
    }
}
