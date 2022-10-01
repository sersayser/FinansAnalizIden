using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinansAnaliz.Controllers
{
    public class CCalenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
