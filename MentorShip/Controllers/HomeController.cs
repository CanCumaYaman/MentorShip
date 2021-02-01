using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MentorShip.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MentorShip.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        
        public IActionResult Index()
        {
            
            return View();
        }


        MixModel m = new MixModel();
        public ActionResult Main(string user)
        {

            IEnumerable<Resumes>  resume;
            if (c.Students.Where(e => e.Email == user).FirstOrDefault() != null)
            {
                
                Student s = c.Students.Where(e => e.Email == user).FirstOrDefault();
                   var result=from deger in c.Resumes
                   where deger.Sid == s.Id
                   select deger;
                resume = result;
                ViewBag.message = s.Ad;
            } else
           
            {
                Mentor mentr = c.Mentors.Where(a => a.Email == user).FirstOrDefault();
                var result = from deger in c.Resumes
                             where deger.Mid == mentr.Id
                             select deger;
                resume = result;
                ViewBag.message = mentr.Ad;
            }



            //TempData["email"] = s.Email;




            var model = new MixModel { mentors = c.Mentors.ToList(), students = c.Students.ToList(),resumes=resume.ToList()};
            return View(model);
        }

       
    }
}
