using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
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
            var result = _queries.ActiveActivitiesQuery(editionId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
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
        public IActionResult ChangeActivityStatus([FromBody] ActivityChangeStatusDto dto)
        {
            _command.ChangeActivityStatusCommand(dto.ActivityId, dto.StatusId);

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
