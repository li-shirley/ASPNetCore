using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
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
            Dachi sessionDachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");

            if (sessionDachi == null)
            {
                Dachi newDachi = new Dachi();
                HttpContext.Session.SetObjectAsJson("Dachi", newDachi);
                return View ("Index", newDachi);
            }
            return View("Index", sessionDachi);
        }

        [HttpGet("/Feed")]
        public IActionResult Feed()
        {
            Dachi sessionDachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");
            sessionDachi.Feed(HttpContext.Session);
            return RedirectToAction("Index");
        }

        [HttpGet("/Play")]
        public IActionResult PLay()
        {
            Dachi sessionDachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");
            sessionDachi.Play(HttpContext.Session);
            return RedirectToAction("Index");
        }

        [HttpGet("/Work")]
        public IActionResult Work()
        {
            Dachi sessionDachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");
            sessionDachi.Work(HttpContext.Session);
            return RedirectToAction("Index");
        }

        [HttpGet("/Sleep")]
        public IActionResult Sleep()
        {
            Dachi sessionDachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");
            sessionDachi.Sleep(HttpContext.Session);
            return RedirectToAction("Index");
        }

        [HttpGet("/Reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.SetObjectAsJson("Dachi", null);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
