using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services;

namespace MxlCalc.Controllers
{
    public class CombinationsController : Controller
    {
        private CombinationService _combinationService;
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.formType = "form1.cshtml";
            return View();
        }
        [HttpPost]
        public IActionResult Index(string answer, string n, string m, string k)
        {
            
            if (n!=null && m == null)
            {
                _combinationService = new CombinationService(n,true);
                ViewBag.TypeOfConfigure = Combinations.TypeOfConfigure;
                ViewBag.Result = Combinations.Result;
            }
            else if (m != null && n == null)
            {
                _combinationService = new CombinationService(m,k,true);
                ViewBag.TypeOfConfigure = Combinations.TypeOfConfigure;
                ViewBag.Result = Combinations.Result;
            }
            else if (n != null && m != null)
            {
                _combinationService = new CombinationService(n,m);
                ViewBag.TypeOfConfigure = Combinations.TypeOfConfigure;
                ViewBag.Result = Combinations.Result;
            }
            else
            {
                _combinationService = new CombinationService(answer);
            }
            ViewBag.formType = _combinationService.Form;
            return View();
        }
      
    }
}
