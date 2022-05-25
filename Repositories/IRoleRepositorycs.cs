using Employee.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Repositories
{
 public   interface IRoleRepositorycs
    {
        Task<string> getAllRoles();
        Role getOneRole(int Id);

        Task<string> postRole(Role rd);

        string updateSingleAdmin(Role rd, int Id);
        string DeleteRole(int Id);

        Task<string> getUserRole(int RoleId);
       
    }
}
