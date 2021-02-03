using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MentorShip.Hubs;
using MentorShip.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MentorShip.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        ErrorViewModel error = new ErrorViewModel();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> SignInStudent(Student s)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();

            string SifrelenecekVeri = s.Parola;

            string SifrelenmisVeri = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(SifrelenecekVeri)));
            var info = c.Students.FirstOrDefault(x => x.Email == s.Email && x.Parola == SifrelenmisVeri);

            if (info != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,s.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);
                var value = from deger in c.Students
                            where deger.Email == s.Email
                            select deger.Email;


                var nameuser = value;
               
                return RedirectToAction("Main", "Home", new { user = nameuser });
            }


            return RedirectToAction("Index", "Home");

        }

       
        [HttpPost]
        public async Task<IActionResult> SignInMentor(Mentor m)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();

            string SifrelenecekVeri = m.Parola;

            string SifrelenmisVeri = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(SifrelenecekVeri)));

            var info = c.Mentors.FirstOrDefault(x => x.Email == m.Email && x.Parola == SifrelenmisVeri);
            if (info != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,m.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                var value = from deger in c.Mentors
                            where deger.Email == m.Email
                            select deger.Email;


                var nameuser = value;
                return RedirectToAction("Main", "Home", new { user = nameuser });


            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index","Home");
        }

    }
}