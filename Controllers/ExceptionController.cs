using Microsoft.AspNetCore.Mvc;
using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Controllers
{
    public class ExceptionController : Controller
    {
        public IActionResult ExceptionHandling(ExMessDTO exMessDTO)
        {
            return View(exMessDTO);
        }
    }
}
