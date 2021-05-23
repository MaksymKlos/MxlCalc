using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MxlCalc.Models;
using Services;


namespace MxlCalc.Controllers
{
    public class BinaryController : Controller
    {
     

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult Operations()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Operations(string setA, string setB, string operation, string type)
        {
            OperationsService operationsServise = new OperationsService(setA, setB, operation, type);
            ViewBag.Result = operationsServise.ToString();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
