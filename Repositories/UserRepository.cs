using Employee.EmpDBContext;
using Employee.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Repositories
{
    public class UserRepository: IUserRepository
    {
private readonly EmployeeDBContext  _context;

        public UserRepository(EmployeeDBContext context)
        {
            _context = context;
        }


        public async Task<List<User>> getAuth()
        {
            var authDetails = await _context.Users.ToListAsync();
            return authDetails;
        }

        public async Task<string> PostAuth(User user)
        {
            var authDetail = await _context.Users.ToListAsync();
         var exist=authDetail.SingleOrDefault(x=> (x.Username== user.Username)|| (x.Password == user.Password));

            if (exist == null)
            {
                try
                {
                    var authDetails = await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync().ConfigureAwait(true);
                    return "Successfully Posted data is  "+ authDetails;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            else
            {
                return "Username already exist";
            }
                                       
           
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

        public  async Task<int> getUserId(string username)
        {
            var role = await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
            return role.Id;
        }

        public async Task<string> updateSingleUser(User us, int Id)
        {
            if (us.Id == Id)
            {
                _context.Entry(us).State =  EntityState.Modified;
                _context.SaveChanges();
                return "Successfully updated user " + us.Id;
            }
            else
            {
                return  "Id not Found ";
            }
        }

        public async  Task<string> DeleteUser(int Id)
        {
            var us = _context.Users.SingleOrDefault(x => x.Id == Id);

            if (us != null)
            {
                _context.Users.Remove(us);
                _context.SaveChanges();
                return "Successfully Deleted  " + us.Id;
            }

            return "Successfully Deleted  " + us.Id;
        }

        //search By Name
        public  async  Task<List<User>>  searchByName(string Name)
        {
            var search =await  _context.Users.Where(x => x.Firstname.Contains(Name) || x.Lastname.Contains(Name)).Select(p => new User() { Firstname = p.Firstname, Lastname = p.Lastname, Id = p.Id, Contactnumber = p.Contactnumber }).ToListAsync();
   
            if (search ==null)
            {
                return null ;
            }
            else
            {
                return search;
            }
            
        }


    }
    }
