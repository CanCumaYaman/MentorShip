using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MentorShip.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult SOLID()
        {
            return View();
        }
        public IActionResult Yazılım_Geliştirici_Yol_Haritası()
        {
            return View();
        }
        public IActionResult OOP()
        {
            return View();
        }
        public IActionResult Hakkımda()
        {
            return View();
        }
        public IActionResult İletişim()
        {
            return View();
        }
      
        public IActionResult Design_Pattern()
        {
            return View();
        }
        public IActionResult Diger()
        {
            return View();
        }
    }
}