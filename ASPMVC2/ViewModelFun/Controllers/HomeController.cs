using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public ViewResult Message()
        {
            string message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum justo erat, auctor et facilisis sed, porttitor a lectus. Curabitur at ornare velit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum ac dignissim neque. Aenean erat nibh, maximus ut sem vel, ullamcorper maximus dui. Vestibulum in dictum dui. Aenean egestas tempus enim id viverra. Morbi id erat molestie, hendrerit metus quis, lobortis tortor.";
            return View("Message", message);
        }

        [HttpGet("numbers")]
        public ViewResult Numbers()
        {
            int[] numbers = {1,2,3,10,43,5};
            return View(numbers);
        }
        
        public List<User> MakeUsers()
        {
            List<User> users = new List<User>()
            {
                new User("Moose", "Phillips"),
                new User("Sarah"),
                new User("Jerry"),
                new User("Rene","Ricky"),
                new User("Barbarah"),
            };
            return users;
        }

        [HttpGet("users")]
        public ViewResult Users()
        {
            List<User> users = MakeUsers();
            return View(users);
        }

        [HttpGet("user")]
        public ViewResult OneUser()
        {
            User firstUser = MakeUsers()[0];
            return View(firstUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
