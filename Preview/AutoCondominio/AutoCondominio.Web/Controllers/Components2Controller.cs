using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoCondominio.ViewModels;

namespace AutoCondominio.Controllers
{
    public class Components2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
