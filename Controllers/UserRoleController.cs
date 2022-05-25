using Employee.Entity;
using Employee.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IAuthService _iAuthService;

        public UserRoleController(IAuthService iAuthService)
        {
            _iAuthService = iAuthService;
        }

        [HttpGet("URoleGet")]
        public async Task<ActionResult<UserRole>> getARoledata()
        {
            var roleDetails = await _iAuthService.getUserRoledata();
            return Ok(roleDetails);
        }

        [HttpPost("URolePost")]
        public async Task<IActionResult> PostRoleData([FromBody] UserRole role)
        {
            var roleDetails = await _iAuthService.PostUserRoleData(role);
            return Ok(roleDetails);
        }



    }
}
