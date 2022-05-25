using Employee.Entity;
using Employee.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class RoleController : ControllerBase
    {
        private readonly IAuthService _iAuthService;

        public RoleController(IAuthService iAuthService)
        {
            _iAuthService = iAuthService;
        }

        [HttpGet("RoleGet")]
        public async Task<ActionResult<Role>> getARoledata()
        {
            var roleDetails = await _iAuthService.getRoledata();
            return Ok(roleDetails);
        }

        [HttpPost("RolePost")]
        public async Task<IActionResult> PostRoleData([FromBody] Role role)
        {
            var roleDetails = await _iAuthService.PostRoleData(role);
            return Ok(roleDetails);
        }


       


    }
}
