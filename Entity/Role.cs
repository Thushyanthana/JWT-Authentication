using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Entity
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string  RoleName { get; set; }



    }
}
