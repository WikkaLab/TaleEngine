using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.CQRS.Contracts;
using TaleEngine.Cross.Enums;

namespace TaleEngine.API.Controllers.V2
{
    [Obsolete("This API version is deprecated. Please use V1 instead.")]
    [ApiController]
    [Route("api/v2/[controller]")]
    public class ActivityController : Controller
    {
        private readonly IActivityCommands _command;
        private readonly IActivityQueries _queries;

        public ActivityController(IActivityCommands command,
            IActivityQueries queries)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        [HttpGet("[action]/{editionId}")]
        public IActionResult GetActivities(int editionId)
        {
            var activities = _queries.ActiveActivitiesQuery(editionId);

            if (activities == null || activities.Count == 0)
            {
                return NoContent();
            }
            return Ok(activities);
        }

        [HttpGet("[action]/{editionId}")]
        public IActionResult GetPendingActivities(int editionId)
        {
            var result = _queries.PendingActivitiesQuery(editionId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("[action]/{editionId}")]
        public IActionResult GetLastThreeActivies(int editionId)
        {
            var result = _queries.LastThreeActivitiesQuery(editionId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult GetActivitiesFiltered([FromBody] ActivityFilterRequest activityFilterRequest)
        {
            var result = _queries.ActiveActivitiesFilteredQuery(activityFilterRequest);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpDelete("[action]/{activityId}")]
        public IActionResult DeleteActivity(int activityId, [FromQuery] int roleId = default, [FromServices] IAssignedPermissionQueries permissionQueries = null)
        {
            var authorized = HasAllowPermission(permissionQueries, roleId, "DELACT");

            if (!authorized)
            {
                return Unauthorized();
            }

            _command.DeleteCommand(activityId);
            return Ok();
        }

        [HttpPost("[action]/{editionId}")]
        public IActionResult CreateActivity(int editionId, [FromBody] ActivityDto activityDto, [FromQuery] int roleId = default, [FromServices] IAssignedPermissionQueries permissionQueries = null)
        {
            var authorized = HasAllowPermission(permissionQueries, roleId, "PROPACT");

            if (!authorized)
            {
                return Unauthorized();
            }

            _command.CreateCommand(editionId, activityDto);
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult ChangeActivityStatus([FromBody] ActivityChangeStatusDto activtyChangeStatusDto)
        {
            _command
                .ChangeActivityStatusCommand(activtyChangeStatusDto.ActivityId, activtyChangeStatusDto.StatusId);

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateActivity([FromBody] ActivityDto activityDto, [FromQuery] int roleId = default, [FromServices] IAssignedPermissionQueries permissionQueries = null)
        {
            var authorized = HasAllowPermission(permissionQueries, roleId, "EDITACT");

            if (!authorized)
            {
                return Unauthorized();
            }

            _command.UpdateCommand(activityDto);
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
