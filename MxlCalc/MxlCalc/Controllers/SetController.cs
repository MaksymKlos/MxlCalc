using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;

namespace MxlCalc.Controllers
{
    public class SetController : Controller
    {
        [HttpGet]
        public IActionResult Index(string calculators)
        {
            if (calculators == "operations")
            {
                return Redirect("/Set/Operations");
            }
            else if (calculators == "equation")
            {
                return Redirect("/Set/Equation");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Operations(string setA, string setB, string operation, string type)
        {
            if (operation != null)
            {
                OperationsService operationsServise = new OperationsService(setA, setB, operation, type);
                ViewBag.Result = operationsServise.ToString();
            }
           
            return View();
        }
    }
}
