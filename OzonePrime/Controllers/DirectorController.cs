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
        private UserService userService;

        public DirectorController(DirectorService directorService, UserService userService)
        {
            this.directorService = directorService;
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
        public ActionResult Create(Director director)
        {
            directorService.Create(director);
            return RedirectToAction("Create");
        }

        
    }
}
