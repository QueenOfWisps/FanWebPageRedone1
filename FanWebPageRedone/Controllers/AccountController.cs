using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FanWebPageRedone.Models;
using Microsoft.AspNetCore.Identity;
using FanWebPageRedone.Repos;

namespace FanWebPageRedone.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        
        public AccountController(UserManager<AppUser> usrMngr, SignInManager<AppUser> signInMngr)
        {
            userManager = usrMngr;
            signInManager = signInMngr;
           
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Username };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginVM
            {
                ReturnUrl = returnURL
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        public ActionResult AccessDenied()
        {
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> LogOff()
        {
           

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }

}

