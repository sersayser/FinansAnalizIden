using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Controllers
{
    public class WarningController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
