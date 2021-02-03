using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorShip.Models
{
    public class ForgetPassword
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string RandomNumber { get; set; }
    }
}
