using Employee.Entity;
using Employee.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _iAuthService;

        public UserController(IAuthService iAuthService)
        {
            _iAuthService = iAuthService;

        }



        private async Task<bool> userValidate(HttpRequest request)
        {
            var token = request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var decodedValue = handler.ReadJwtToken(token);
            var role = decodedValue.Claims.First(claim => claim.Type == "role").Value;
            if (role == RoleConstant.Admin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        [HttpGet("UserAuthGet")]
        public async Task<List<User>> getAuthdata()
        {
            var authDetails = await _iAuthService.getAuthdata();
            return authDetails;
        }

        [HttpPost("UserAuthPost")]
        public async Task<IActionResult> PostAuthData([FromBody] User user)
        {
            if (!await userValidate(Request))
            {
                return Unauthorized();
            }
            else
            {
                var authDetails = await _iAuthService.PostAuthData(user);
                return Ok(authDetails);
            }
        }

        [HttpPut("UserPut/{Id}")]
        public async Task<ActionResult<string>> updateUser([FromBody] User us, [FromRoute] int Id)
        {
            if (!await userValidate(Request))
            {
                return Unauthorized();
            }
            else
            {
                var uroleUpdate = await _iAuthService.updateSingleUs(us, Id);
                return (uroleUpdate);
            }
        }

        [HttpDelete("UserDelete/{Id}")]
        public async Task<ActionResult<string>> deleteUser([FromRoute] int Id)
        {
            if (!await userValidate(Request))
            {
                return Unauthorized();
            }
            else
            {
                var uroleDelete = await _iAuthService.DeleteUser(Id);
                return (uroleDelete);
            }
        }

        //Get Token    
        [AllowAnonymous]
        [HttpPost("authentication")]
        public async Task<IActionResult> AuthenticationToken(Authoirization user)
        {
            var token = await _iAuthService.Authentication(user.Username, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        //Search by Name
        [HttpGet("Search/{searchString}")]
        public  async Task<ActionResult<List<User>>> getSearchperson([FromRoute]string searchString)
            {
            var result =await _iAuthService.searchUser(searchString);
            return result;
            }

    }
}
