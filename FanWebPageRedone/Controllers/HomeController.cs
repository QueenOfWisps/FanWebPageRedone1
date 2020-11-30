using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FanWebPageRedone.Models;
using Microsoft.EntityFrameworkCore;

namespace FanWebPageRedone.Controllers
{
    public class HomeController : Controller
    {
        StoriesContext context; //initialize
        public HomeController(StoriesContext c)
        {
            context = c; //object passed in and assigning object to context. 

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History() 
        { 
            return View(); 
        }

        public IActionResult Stories()
        {
            Story model = new Story();//new object story created.
            User userName = new User();//new object created
            userName.Name = "Test";
            userName.UserId = 1;
            model.User = userName; //you need to make the username from the model equal the initialized model.
            return View(model); //put model into view.
        }


        [HttpPost]
        public IActionResult Stories(Story model) //specify class/model, then pass in the created model that is story.
        {
            model.User = new User();
            model.User.Name = model.UserName;
            context.Story.Add(model);
            context.SaveChanges();
            return View(model);// pass in that model to view. 

        }
        public IActionResult Story() 
        {
            var stories = context.Story.Include(Story => Story.User).ToList<Story>();
            return View(stories);
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
