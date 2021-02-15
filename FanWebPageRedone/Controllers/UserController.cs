using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FanWebPageRedone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using FanWebPageRedone.Repos;


namespace FanWebPageRedone.Controllers
{
    //page 691
    // ignore when youa dd authorization to admin page ignore area admin we do not have one called area. 

   // [Authorize(Roles = "Admin")]
    //[Authorize]
    public class UserController : Controller
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        Istories repo;
        public UserController( UserManager<AppUser> userMngr, RoleManager<IdentityRole> roleMngr,Istories r)
        {
            userManager = userMngr;
            roleManager = roleMngr;
            repo = r;

        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = new List<AppUser>();
            foreach(AppUser user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }
            UserVM model = new UserVM
            {
                Users = users,
                Roles = roleManager.Roles
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                //check if they have stories
                //StoriesContext context = new StoriesContext(new Microsoft.EntityFrameworkCore.DbContextOptions<StoriesContext>());
                //var stories = context.Story.Where(s => s.User.Id == id).ToList();
                // context.Story.RemoveRange(stories);

                //context.SaveChanges();
                var deleteList = repo.Story.Where(s => s.User.Id == id).ToList();
                

                IdentityResult result = await userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    string errorMessage = "";
                    foreach(IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";

                    }
                    TempData["message"] = errorMessage;
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            var roleExists = await roleManager.RoleExistsAsync("Admin");

            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                TempData["message"] = "Admin role does not exist. " + "Click 'Create Admin Role' button to create it";
            }
            else
            {
                
                AppUser user = await userManager.FindByIdAsync(id);
                var result = await userManager.AddToRoleAsync(user,"Admin");
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await roleManager.FindByNameAsync(id);
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            return RedirectToAction("Index");
        }




    }
}
