using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class ActivityController : Controller
    {
        private readonly IActivityCommands _command;

        public ActivityController(IActivityCommands command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
        }

        [HttpGet("[action]/{editionId}")]
        public IActionResult GetActivities(int editionId)
        {
            var result = _command.ActiveActivitiesQuery(editionId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("[action]/{editionId}")]
        public IActionResult GetPendingActivities(int editionId)
        {
            var result = _command.PendingActivitiesQuery(editionId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("[action]/{editionId}")]
        public IActionResult GetLastThreeActivies(int editionId)
        {
            var result = _command.LastThreeActivitiesQuery(editionId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult GetActivitiesFiltered([FromBody] ActivityFilterRequest activityFilterRequest)
        {
            var result = _command.ActiveActivitiesFilteredQuery(activityFilterRequest);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpDelete("[action]/{activityId}")]
        public IActionResult DeleteActivity(int activityId)
        {
            //var authorized = false;

            //if (!authorized)
            //{
            //    return Unauthorized();
            //}

            _command.DeleteCommand(activityId);
            return Ok();
        }

        [HttpPost("[action]/{editionId}")]
        public IActionResult CreateActivity(int editionId, [FromBody] ActivityDto activityDto)
        {
            //var authorized = true;

            //if (!authorized)
            //{
            //    return NoContent();
            //}

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
        public IActionResult UpdateActivity([FromBody] ActivityDto activityDto)
        {
            //var authorized = false;

            //if (!authorized)
            //{
            //    return Unauthorized();
            //}

            _command.UpdateCommand(activityDto);
            return Ok();
        }
    }
}
