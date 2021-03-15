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

        public GenreController(GenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            genreService.Create(genre);
            return RedirectToAction("Create");
        }        
    }
}
