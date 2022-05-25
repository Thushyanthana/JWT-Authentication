using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Response
{
    public class UserRes
    {
        [Key]
        public int Id { get; set; }

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
