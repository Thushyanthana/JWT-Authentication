using Employee.EmpDBContext;
using Employee.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Repositories
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly EmployeeDBContext _context;

        public UserRoleRepository(EmployeeDBContext context)
        {
            _context = context;
        }


        public async Task<List<UserRole>> getUserRole()
        {
            var UserRoleDetails = await _context.UserRoles.ToListAsync();
            return UserRoleDetails;
        }

        public async Task<string> PostUserRole(UserRole urole)
        {               
                    var roleDetails = await _context.UserRoles.AddAsync(urole);
                    await _context.SaveChangesAsync().ConfigureAwait(true);
                    return "Successfully Posted data is  " + roleDetails;                
        }

        public async Task<User> getUsernameById(int StudentId)
        {
            var User = await _context.Users.SingleOrDefaultAsync(x => StudentId == x.Id);
            return User;
        }

        public async Task<int> getUserID(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
            return user.Id;
        }

      public async Task<int>   getUserRoleId(int userId)
        {
            var userrole= await _context.UserRoles.SingleOrDefaultAsync(x => x.UserId == userId);
            return userrole.RoleId;
        }


    }
}
