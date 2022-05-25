using Employee.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.EmpDBContext
{
    public class EmployeeDBContext: DbContext
    {

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext>  options ):base(options)
        {

        }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


    }
}
