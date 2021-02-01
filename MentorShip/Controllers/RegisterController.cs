using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MentorShip.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MentorShip.Controllers
{
    public class RegisterController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUpStudent()
        {
            return View();

        }
        [HttpPost]
        public IActionResult SignUpStudent(Student s)
        {
            string encrypted = Hashing(s.Parola);
            var user = new Student()
            {
                Ad = s.Ad,
                Soyad = s.Soyad,
                Departmant = s.Departmant,
                Email = s.Email,
                Parola = encrypted

            };
            c.Students.Add(user);
            c.SaveChanges();
            return RedirectToAction("Index", "Home");
            
        }
        public string Hashing(string password)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();

            string encrypting = password;

            string SifrelenmisVeri = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(encrypting)));
            return SifrelenmisVeri;

        }
       [HttpGet]
        public IActionResult SignUpMentor()
        {
            return View();
        }

        [HttpPost]
      
        public IActionResult SignUpMentor(Mentor m)
        {
            string encrypted = Hashing(m.Parola);
            var mentor = new Mentor()
            {
                Ad = m.Ad,
                Soyad = m.Soyad,
                Departmant = m.Departmant,
                Job=m.Job,
                Email = m.Email,
                Parola = encrypted

            };
            c.Mentors.Add(mentor);
            c.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Update(string Email,string Parola)
        {
            var deger=" " ;
            if (c.Students.Where(e => e.Email == Email).FirstOrDefault() != null)
            {
                Student s = c.Students.Where(e => e.Email == Email).FirstOrDefault();
                s.Ad = s.Ad;
                s.Soyad = s.Soyad;
                s.Departmant = s.Departmant;
                s.Email = Email;
                deger = Email;
                s.Parola = Hashing(Parola);
                c.SaveChanges();

            }
            else
            {
                Mentor m = c.Mentors.Where(e => e.Email == Email).FirstOrDefault();
                m.Ad = m.Ad;
                m.Soyad = m.Soyad;
                m.Departmant = m.Departmant;
                m.Email = Email;
                deger = Email;
                m.Parola = Hashing(Parola);
                c.SaveChanges();
            }

            return RedirectToAction("Main", new RouteValueDictionary(
   new { controller = "Home", action = "Main", user = deger}));
        }
    }
    
}