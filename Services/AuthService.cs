using Employee.Entity;
using Employee.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Services
{
    public class AuthService : IAuthService
    {
        private TokenSettingModel tokenSetting;
        private readonly IRoleRepositorycs _iroleRepositorycs;
        private readonly IUserRepository _iuserRepository;
        private readonly IUserRoleRepository _iuserRoleRepository;
        public AuthService(TokenSettingModel _tokenSetting, IUserRepository iuserRepository
            , IRoleRepositorycs iroleRepositorycs,
            IUserRoleRepository iuserRoleRepository)
        {
            tokenSetting = _tokenSetting;
            _iuserRepository = iuserRepository;
            _iroleRepositorycs = iroleRepositorycs;
            _iuserRoleRepository = iuserRoleRepository;
        }

        public async Task<List<User>> getAuthdata()
        {
            var authDetails = await _iuserRepository.getAuth();
            return authDetails;
        }

        public async Task<string> PostAuthData(User user)
        {
            var authDetails = await _iuserRepository.PostAuth(user);
            return (authDetails);
        }




        public async Task<string> Authentication(string username, string password)
        {
            var key = tokenSetting.Key;
            var  userId =await  _iuserRepository.getUserId(username);
            var RoleId =await _iuserRoleRepository.getUserRoleId(userId);
            var role = await _iroleRepositorycs.getUserRole(RoleId);

            if (!(username.Equals(username) || password.Equals(password)))
            {
                return null;
            }

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role,role.ToString()),
                        new Claim("userid",userId.ToString())
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }


        //Role Service 
        public async Task<string> getRoledata()
        {
            var authDetails = await _iroleRepositorycs.getAllRoles();
            return authDetails;
        }

        public async Task<string> PostRoleData(Role role)
        {
            var authDetails = await _iroleRepositorycs.postRole(role);
            return (authDetails);
        }


        //UserRole Service
        public async Task<List<UserRole>> getUserRoledata()
        {
            var uroleDetails = await _iuserRoleRepository.getUserRole();
            return uroleDetails;
        }

        public async Task<string> PostUserRoleData(UserRole urole)
        {
            var uroleDetails = await _iuserRoleRepository.PostUserRole(urole);
            return (uroleDetails);
        }

        public async Task<string> updateSingleUs(User us, int Id)
        {
         var uroleUpdate = await _iuserRepository.updateSingleUser(us,Id);
            return (uroleUpdate);

        }

        public async Task<string> DeleteUser(int Id)
        {
            var uroleDelete = await _iuserRepository.DeleteUser( Id);
            return (uroleDelete);
        }

        public async Task<List<User>> searchUser(string searchstring)
        {
            var search = await _iuserRepository.searchByName(searchstring);
            return search;
        }

    }
}
