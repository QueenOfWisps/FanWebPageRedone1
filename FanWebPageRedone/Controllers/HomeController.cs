using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FanWebPageRedone.Models;
using Microsoft.EntityFrameworkCore;
using FanWebPageRedone.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FanWebPageRedone.Controllers
{
    public class HomeController : Controller
    {
        Istories repo;
        UserManager<AppUser> userManager;


        public HomeController(Istories r, UserManager<AppUser> u)
        {
            //object passed in and assigning object to context. 
            repo = r;
            userManager = u;

        }

        public IActionResult Index()
        {
            var user = User;
            if (User.IsInRole("Admin"))
            {
                bool isAdmin = true;
            }

            return View();
        }

        public IActionResult History() 
        { 
            return View(); 
        }

        public IActionResult Stories()
        {
            Story model = new Story();//new object story created.
            AppUser userName = new AppUser();//new object created
            userName.Name = "Test";
            model.User = userName;
            //you need to make the username from the model equal the initialized model.
            
            return View(model); //put model into view.
        }

 
        [HttpPost]
        public IActionResult Stories(Story model) //specify class/model, then pass in the created model that is story.
        {
           // model.User = new User();
            if(ModelState.IsValid)
            {
                model.User = repo.GetUser(User.Identity.Name);
                repo.AddStory(model);
                return Redirect("Story");// pass to story
            }
            else
            {
                AddErrors();
                return View(model);
            }

        }
        public IActionResult Story(string date, string name) 
        {
            // var stories = context.Story.Include(Story => Story.User).ToList<Story>();
            // return View(stories);
            //List<Story> story = repo.Story.ToList<Story>();
            List<Story> stories = new List<Story>();

            var testAll = repo.Story.ToList();

            if (!String.IsNullOrEmpty(name))
            {
                stories = (from r in repo.Story
                           where r.User.Name == name
                           select r).ToList();    
            }
            else if (!String.IsNullOrEmpty(date))
            {
                var parseDate = DateTime.Parse(date);
                stories = (from r in repo.Story
                           where r.Date.Date == parseDate.Date
                           select r).ToList();
            }
            return View(stories);
            
        }


        [Authorize]
        public IActionResult Comment(int reviewId)
        {
            var commentVM = new CommentVM { StoryID = reviewId };
            return View(commentVM);
        }

        [HttpPost]
        public RedirectToActionResult Comment(CommentVM commentVM)
        {
            // Comment is the domain model
            var comment = new Comment { CommentText = commentVM.CommentText };
            comment.Commenter = userManager.GetUserAsync(User).Result;
            comment.CommentDate = DateTime.Now;

            // Retrieve the review that this comment is for
            var review = (from r in repo.Story
                          where r.StoryId == commentVM.StoryID
                          select r).First<Story>();

            // Store the review with the comment in the database
            review.Comments.Add(comment);
            repo.UpdateStory(review);

            return RedirectToAction("Reviews");
        }
        private void AddErrors()
        {
            ModelState.AddModelError("", "Error has occured.");
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


        public IActionResult Registration()
        {
            return View(new RegisterVM());

        }

        [HttpPost]
        public IActionResult Registration(RegisterVM model)
        {
            //check if the model is valid
            //create user
            //if (ModelState.IsValid)
            //{
            //    repo.AddUser(model);
            //}

            return View();
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
