using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.Backoffice
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignedPermissionController : Controller
    {
        private readonly IAssignedPermissionQueries _queries;
        private readonly IAssignedPermissionCommands _commands;

        public AssignedPermissionController(IAssignedPermissionQueries queries, IAssignedPermissionCommands commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllAssignedPermissions()
        {
            var result = _queries.AllAssignedPermissionsQuery();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("[action]/{roleId}")]
        public IActionResult GetPermissionsByRole(int roleId)
        {
            var result = _queries.GetPermissionsByRoleQuery(roleId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult AssignPermission([FromBody] AssignPermissionRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            _commands.AssignPermissionCommand(request);
            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult RemovePermission([FromBody] AssignPermissionRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            _commands.RemovePermissionCommand(request);
            return Ok();
        }
    }
}
