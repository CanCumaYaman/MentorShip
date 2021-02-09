using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorShip.Models
{
    public class MixModel
    {
        public IEnumerable<Student> students { get; set; }
        public IEnumerable<Mentor> mentors { get; set; }
        public IEnumerable<Resumes> resumes { get; set; }
        


    }
}
