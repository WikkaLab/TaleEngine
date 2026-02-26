using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionValueController : Controller
    {
        private readonly IPermissionValueQueries _queries;
        private readonly IPermissionValueCommands _commands;

        public PermissionValueController(IPermissionValueQueries queries, IPermissionValueCommands commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet("[action]")]
        public IActionResult GetPermissionValues()
        {
            var result = _queries.AllPermissionValuesQuery();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetPermissionValue(int id)
        {
            var result = _queries.GetPermissionValueQuery(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult CreatePermissionValue([FromBody] PermissionValueDto permissionValueDto)
        {
            if (permissionValueDto == null)
            {
                return BadRequest();
            }

            _commands.CreateCommand(permissionValueDto);
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult UpdatePermissionValue([FromBody] PermissionValueDto permissionValueDto)
        {
            if (permissionValueDto == null)
            {
                return BadRequest();
            }

            _commands.UpdateCommand(permissionValueDto);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeletePermissionValue(int id)
        {
            _commands.DeleteCommand(id);
            return Ok();
        }
    }
}
