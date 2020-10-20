using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FanWebPageRedone.Controllers
{
    public class SourceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    public IActionResult BooksAndPrint()
        {
            return View();
        }
      
    public IActionResult Links()
        {
            return View();
        }
       
    }

}
