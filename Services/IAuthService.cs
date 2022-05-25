using Employee.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Services
{
  public  interface IAuthService
    {
        Task<List<User>> getAuthdata();
        Task<string> PostAuthData(User user);
        Task<string> Authentication(string username, string password);
        Task<string> updateSingleUs(User us, int Id);
        Task<string> DeleteUser(int Id);
        Task<List<User>> searchUser(string searchstring);

        //Role  Servive
        Task<string> getRoledata();
        Task<string> PostRoleData(Role role);

        //URole Service
        Task<List<UserRole>> getUserRoledata();
        Task<string> PostUserRoleData(UserRole urole);


    }
}
