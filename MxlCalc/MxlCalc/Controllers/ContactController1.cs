﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MxlCalc.Controllers
{
    public class ContactController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
