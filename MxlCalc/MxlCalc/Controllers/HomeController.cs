using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MxlCalc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MxlCalc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(string themes)
        {
            if (themes == "sets")
            {
                return Redirect("/Set/Index");
            }
            else if (themes == "binary__relations")
            {
                return Redirect("/Binary/Index");
            }
            else if (themes == "combinations")
            {
                return Redirect("/Combinations/Index");
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
