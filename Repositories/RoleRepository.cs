using Employee.EmpDBContext;
using Employee.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Repositories
{
    public class RoleRepository: IRoleRepositorycs
    {
        private readonly EmployeeDBContext _context;
        public RoleRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<string> getAllRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            if (roles != null)
            {
                try
                {
                    return "The Role records " + roles.ToList();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            else
            {
                return (" There is no record avilable");
            }
          
        }

        public Role getOneRole(int Id)
        {
            var ro = _context.Roles.SingleOrDefault(x => x.Id == Id);
            return ro;
        }

        public async Task<string> postRole(Role rd)
        {
            var  existRole= await _context.Roles.ToListAsync();
            if (null==existRole.SingleOrDefault(x=> x.RoleName==rd.RoleName))
            {
                try
                {
                    var role = _context.Roles.Add(rd);
                    await _context.SaveChangesAsync().ConfigureAwait(true);
                    return  "Succefully Added  " +role.Entity.Id+ role.Entity.RoleName;
                }
                catch(Exception e)
                {
                    throw;
                }
            }
            else
            {
                return "Role Record already exist";
            }
            
        }


        public string updateSingleAdmin(Role rd, int Id)
        {
            if (rd.Id == Id)
            {
                _context.Entry(rd).State = EntityState.Modified;
                _context.SaveChanges();
                return "Successfully updated " + Id;
            }
            else
            {
                return "Id not Found ";
            }

        }

        public string DeleteRole(int Id)
        {
            var ad = _context.Roles.SingleOrDefault(x => x.Id == Id);

            if (ad != null)
            {
                _context.Roles.Remove(ad);
                _context.SaveChanges();
                return "Successfully Deleted  " + ad.Id;
            }
            else
            {
                return "Id is Not there Cannot delete a Role";
            }
        }

        public async Task<string>   getUserRole(int RoleId)
        {
            var role =await _context.Roles.SingleOrDefaultAsync(x=> x.Id== RoleId);
            return role.RoleName;
        }


    }
}
