using Employee.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Repositories
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> getUserRole();
        Task<string> PostUserRole(UserRole urole);
        Task<int> getUserRoleId(int userId);
    }
}
