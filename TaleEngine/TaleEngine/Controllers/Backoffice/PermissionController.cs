using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : Controller
    {
        private readonly IPermissionQueries _queries;
        private readonly IPermissionCommands _commands;

        public PermissionController(IPermissionQueries queries, IPermissionCommands commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet("[action]")]
        public IActionResult GetPermissions()
        {
            var result = _queries.AllPermissionsQuery();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetPermission(int id)
        {
            var result = _queries.GetPermissionQuery(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult CreatePermission([FromBody] PermissionDto permissionDto)
        {
            if (permissionDto == null)
            {
                return BadRequest();
            }

            _commands.CreateCommand(permissionDto);
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult UpdatePermission([FromBody] PermissionDto permissionDto)
        {
            if (permissionDto == null)
            {
                return BadRequest();
            }

            _commands.UpdateCommand(permissionDto);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeletePermission(int id)
        {
            _commands.DeleteCommand(id);
            return Ok();
        }
    }
}
