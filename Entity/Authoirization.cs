using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Entity
{
    public class Authoirization
    {
        [Required]
        public string Username { get; set; }

        [StringLength(6)]
        [Required]
        public string Password { get; set; }

       
        public string Contactnumber { get; set; }

    }
}
