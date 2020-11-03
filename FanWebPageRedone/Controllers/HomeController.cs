using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FanWebPageRedone.Models;

namespace FanWebPageRedone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History() { return View(); }

        public IActionResult Stories()
        {
            Story model = new Story();//new object story created.
            User userName = new User();//new object created
            model.UserName = userName; //you need to make the username from the model equal the initialized model.
            return View(model); //put model into view.
        }

        [HttpPost]
        public IActionResult Stories(Story model) //specify class/model, then pass in the created model that is story.
        {
            return View(model);// pass in that model to view. 

        }
        [HttpGet]
        public IActionResult Quiz() 
        {
            return View();
        }

        [HttpPost]

        public IActionResult Quiz(QuizVM quiz) 
        {
            quiz.CheckAnswers();
            return View(quiz);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
