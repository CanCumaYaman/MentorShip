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
using System.Net.Mail;
using Microsoft.AspNetCore.Routing;

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
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        public IActionResult EnterCode(string user)
        {
            ViewBag.message = user;
            return View();
        }
        [HttpPost]
        public IActionResult ControlCode(string email,string code)
        {
            
            var forget = c.ForgetPasswords.FirstOrDefault(p=>p.Email==email&&p.RandomNumber==code);
            if (forget != null)
            {
                return RedirectToAction("PasswordReset", "Home", new { user = email });
            }

            return View();
        }
        [HttpGet]
        public IActionResult PasswordReset(string user)
        {
            ViewBag.message = user;
            return View();
        }
        [HttpPost]
        public IActionResult PasswordReset(string mail,string password)
        {
            RegisterController registerController = new RegisterController();
            var deger=" " ;
            if (c.Students.Where(e => e.Email == mail).FirstOrDefault() != null)
            {
                Student s = c.Students.Where(e => e.Email == mail).FirstOrDefault();
                s.Ad = s.Ad;
                s.Soyad = s.Soyad;
                s.Departmant = s.Departmant;
                s.Email = mail;
                deger = mail;
                s.Parola =registerController.Hashing(password);
                c.SaveChanges();

            }
            else
            {
                Mentor m = c.Mentors.Where(e => e.Email == mail).FirstOrDefault();
                m.Ad = m.Ad;
                m.Soyad = m.Soyad;
                m.Departmant = m.Departmant;
                m.Email = mail;
                deger = mail;
                m.Parola = registerController.Hashing(password);
                c.SaveChanges();
            }

            return RedirectToAction("Main", new RouteValueDictionary(
   new { controller = "Home", action = "Main", user = deger}));

            
        }

        [HttpPost]
        public IActionResult ForgetPassword(string email)
        {
            Student s = c.Students.Where(e => e.Email == email).FirstOrDefault();

            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("bumdakum@gmail.com");

            ePosta.To.Add(email);



            ePosta.Subject = "Şifre Hatırlatma";
            Random rnd = new Random();
            string code = rnd.Next(0, 10000).ToString();

            ePosta.Body =code ;
            ForgetPassword forgetPassword = new ForgetPassword();
            forgetPassword.Email = email;
            forgetPassword.RandomNumber = code;
            c.ForgetPasswords.Add(forgetPassword);
            c.SaveChanges();
            SmtpClient smtp = new SmtpClient();

            smtp.Credentials = new System.Net.NetworkCredential("bumdakum@gmail.com", "166.1222a");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;

            }
            return RedirectToAction("EnterCode", "Home", new { user = email });

        }


    }
}
