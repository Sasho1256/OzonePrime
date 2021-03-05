using Microsoft.AspNetCore.Mvc;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string username, string password, string firstName, string lastName)
        {
            this.userService.Register(username, password, firstName, lastName);
            return RedirectToAction(nameof(GetAllFilms));
        }

        private object GetAllFilms()
        {
            return View(userService.database.Films.ToList());
        }
    }
}
