using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorShip.Models
{
    public class Mentor
    {
        [Key]
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }
        public string Departmant { get; set; }
        public string Job { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
    }
}