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

        public IActionResult UserProfile()
        {
            User user = new User();
            try
            {
                user = this.userService.UserProfile();
            }
            catch (AccessViolationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                this.userService.Register(user);
            }
            catch (AccessViolationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            catch (DuplicateNameException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(User user)
        {
            try
            {
                this.userService.LogIn(user);
            }
            catch (MissingMemberException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            catch (AccessViolationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            userService.LogOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditProfile(User user)
        {
            try
            {
                this.userService.EditProfile(user);
            }            
            catch (DuplicateNameException ex)
            {                
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            return RedirectToAction("UserProfile");
        }

        //[HttpGet]
        //public IActionResult AddFilmToMyList()
        //{
        //    return RedirectToAction("GetAllFilms", "Film");
        //}
        //[HttpPost]
        //public IActionResult AddFilmToMyList(Film film)
        //{
        //    userService.AddFilmToMyList(film);

        //    return RedirectToAction("GetAllFilms", "Film");
        //}

        public IActionResult GetMyList()
        {
            List<Film> myList = userService.GetMyList();

            return View(myList);
        }

        [HttpGet]
        public IActionResult RemoveFilmFromMyList()
        {
            return RedirectToAction("GetMyList");
        }
        [HttpPost]
        public IActionResult RemoveFilmFromMyList(string filmId)
        {
            userService.RemoveFilmFromMyList(filmId);

            return RedirectToAction("GetMyList");
        }

        public IActionResult DeleteUser()
        {
            userService.DeleteUser();
            return RedirectToAction("Index", "Home");
        }        

        public IActionResult AreYouSure()
        {            
            return View();
        }
    }
}
