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
        public IActionResult Register(User user)
        {
            this.userService.Register(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
