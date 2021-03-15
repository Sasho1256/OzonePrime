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
    public class DirectorController : Controller
    {
        private DirectorService directorService;

        public DirectorController(DirectorService directorService)
        {
            this.directorService = directorService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Director director)
        {
            directorService.Create(director);
            return RedirectToAction("Create");
        }

        
    }
}
