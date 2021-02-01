using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorShip.Models
{
    public class Resumes
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public string Experience { get; set; }
        public string HighSchool { get; set; }
        public string University { get; set; }
        
        public string ForeignLanguages { get; set; }
        public string Skills { get; set; }
        public string Hobbies { get; set; }
        public int Sid { get; set; }
        public int Mid { get; set; }
    }
}
