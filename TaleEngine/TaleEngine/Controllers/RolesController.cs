using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllRoles()
        {
            var result = _roleService.GetAllRoles();

            return Ok(result);
        }

        [HttpGet("[action]/{roleId:int}")]
        public IActionResult GetRole(int roleId)
        {
            return Ok();
        }

    }
}
