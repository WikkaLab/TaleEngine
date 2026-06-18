using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.Cross.Enums;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationQueries _queries;
        private readonly ILocationCommands _commands;

        public LocationController(ILocationQueries queries, ILocationCommands commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet("[action]/{editionId}")]
        public IActionResult GetLocationsByEdition(int editionId)
        {
            var result = _queries.LocationsByEditionQuery(editionId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("[action]/{locationId}")]
        public IActionResult GetLocation(int locationId)
        {
            var result = _queries.GetLocationQuery(locationId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult CreateLocation([FromBody] LocationDto locationDto, [FromQuery] int roleId = default, [FromServices] IAssignedPermissionQueries permissionQueries = null)
        {
            var authorized = HasAllowPermission(permissionQueries, roleId, "CRELOC");

            if (!authorized)
            {
                return Unauthorized();
            }

            _commands.CreateCommand(locationDto);
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateLocation([FromBody] LocationDto locationDto, [FromQuery] int roleId = default, [FromServices] IAssignedPermissionQueries permissionQueries = null)
        {
            var authorized = HasAllowPermission(permissionQueries, roleId, "EDITLOC");

            if (!authorized)
            {
                return Unauthorized();
            }

            _commands.UpdateCommand(locationDto);
            return Ok();
        }

        [HttpDelete("[action]/{locationId}")]
        public IActionResult DeleteLocation(int locationId, [FromQuery] int roleId = default, [FromServices] IAssignedPermissionQueries permissionQueries = null)
        {
            var authorized = HasAllowPermission(permissionQueries, roleId, "DELLOC");

            if (!authorized)
            {
                return Unauthorized();
            }

            _commands.DeleteCommand(locationId);
            return Ok();
        }

        private static bool HasAllowPermission(IAssignedPermissionQueries permissionQueries, int roleId, string permissionAbbr)
        {
            if (permissionQueries == null || roleId == default || string.IsNullOrWhiteSpace(permissionAbbr))
            {
                return false;
            }

            var rolePermissions = permissionQueries.GetPermissionsByRoleQuery(roleId);

            if (rolePermissions == null || rolePermissions.Count == 0)
            {
                return false;
            }

            return rolePermissions.Any(p =>
                p.PermissionValueId == (int)PermissionValueEnum.ALLOW
                && p.Permission != null
                && string.Equals(p.Permission.Abbr, permissionAbbr, StringComparison.OrdinalIgnoreCase));
        }
    }
}
