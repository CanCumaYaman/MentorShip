using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorShip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MentorShip.Controllers
{
    public class StudentInfoController : Controller
    {
        Context c = new Context();


        public IActionResult UpdateResume(Resumes r)
        {
            var deger = " ";
            if (c.Resumes.Where(e => e.Sid == r.Sid&&r.Mid==0).SingleOrDefault() != null)
            {

                Resumes x = c.Resumes.Where(e => e.Sid == r.Sid).FirstOrDefault();
                Student s = c.Students.Where(k => k.Id == r.Sid).FirstOrDefault();
                deger = s.Email;
                x.PhoneNumber = r.PhoneNumber;
                x.Address = r.Address;
                x.Experience = r.Experience;
                x.Dob = r.Dob;
                x.ForeignLanguages = r.ForeignLanguages;
                x.HighSchool = r.HighSchool;
                x.Hobbies = r.Hobbies;
                x.Skills = r.Skills;
                x.University = r.University;
                c.Resumes.Update(x);
                c.SaveChanges();
            }
            else if (c.Resumes.Where(e => e.Mid == r.Mid && r.Sid == 0).SingleOrDefault() != null)
            {
                Resumes y = c.Resumes.Where(e => e.Sid == r.Sid).FirstOrDefault();
                Mentor m = c.Mentors.Where(k => k.Id == r.Mid).FirstOrDefault();
                deger = m.Email;
                y.PhoneNumber = r.PhoneNumber;
                y.Address = r.Address;
                y.Experience = r.Experience;
                y.Dob = r.Dob;
                y.ForeignLanguages = r.ForeignLanguages;
                y.HighSchool = r.HighSchool;
                y.Hobbies = r.Hobbies;
                y.Skills = r.Skills;
                y.University = r.University;
                c.Resumes.Update(y);
                c.SaveChanges();

            }


            return RedirectToAction("Main", new RouteValueDictionary(
    new { controller = "Home", action = "Main", user = deger }));
        }


    }

}