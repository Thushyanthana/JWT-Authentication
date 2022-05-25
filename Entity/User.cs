using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string Username { get; set; }

        [StringLength(6)]
        [Required]
        public string Password  { get; set; }

        [StringLength(50)]
        [Required]
        public string Firstname { get; set; }


        [StringLength(50)]
        [Required]
        public string Lastname { get; set; }


        [Required]
        public int Age { get; set; }

        [Required]
        public string Contactnumber { get; set; }

        
    }
}
