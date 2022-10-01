using FinansAnaliz.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string phone)
        {
            string message = $"{phone} numaralı müşteri randevu istemek için numarasını bıraktı!";
            string subject = "FinansMetre Yeni Müşteri Randevu Talebi";
            SendMail.SendingMail("serkansaykal@gmail.com", message, subject);
            return View();
        }
    }
}
