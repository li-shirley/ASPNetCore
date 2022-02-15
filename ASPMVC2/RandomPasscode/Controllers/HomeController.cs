using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/generatepw")]
        public IActionResult GeneratePassword()
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder password = new StringBuilder();
            Random letter = new Random();
            for (int i = 0; i < 14; i++)
            {
                password.Append(characters[letter.Next(characters.Length)]);
            }
            HttpContext.Session.SetString("Password", password.ToString());

            int? count = HttpContext.Session.GetInt32("Count");
            if(count == null)
            {
                count = 1;
            }
            else
            {
                count += 1;
            }
            HttpContext.Session.SetInt32("Count", (int)count);
            
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
