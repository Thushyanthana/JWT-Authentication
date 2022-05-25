using Employee.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> getAuth();
        Task<string> PostAuth(User user);
        Task<int> getUserId(string username);
        Task<string> updateSingleUser(User us, int Id);
        Task<string> DeleteUser(int Id);
        Task<List<User>> searchByName(string Name);
    }
}
