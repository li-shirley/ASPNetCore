using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers
{
    public class FormController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("result")]
        public IActionResult Result(Survey yourSurvey)
        {
            return View("Result", yourSurvey);
        }
    }
}