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
        private string exMessage = "";

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
                //return RedirectToAction("LogIn", "User");
                TempData["ExHand"] = ex.Message;
                return RedirectToAction("ExceptionHandling");
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
                //return RedirectToAction("UserProfile", "User");
                TempData["ExHand"] = ex.Message;
                return RedirectToAction("ExceptionHandling");
            }
            catch (DuplicateNameException ex)
            {
                //return RedirectToAction("Register", "User");
                TempData["ExHand"] = ex.Message;
                return RedirectToAction("ExceptionHandling");
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
                //return RedirectToAction("LogIn", "User");
                TempData["ExHand"] = ex.Message;
                return RedirectToAction("ExceptionHandling");
            }
            catch (AccessViolationException ex)
            {
                //return RedirectToAction("UserProfile", "User");
                TempData["ExHand"] = ex.Message;
                return RedirectToAction("ExceptionHandling");
            }
            catch (InvalidOperationException ex)
            {
                //return RedirectToAction("LogIn", "User");
                TempData["ExHand"] = ex.Message;
                return RedirectToAction("ExceptionHandling");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            userService.LogOut();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ExceptionHandling()
        {
            exMessage = TempData["ExHand"].ToString();
            ExMessDTO exMess = new ExMessDTO(exMessage);
            return View(exMess);
        }
    }
}
