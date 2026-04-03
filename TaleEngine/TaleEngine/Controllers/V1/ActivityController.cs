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

        [HttpPut("[action]/{userId}")]
        public IActionResult GetFavouriteActivitiesFiltered(int userId, [FromBody] ActivityFilterRequest activityFilterRequest)
        {
            var result = _queries.ActiveActivitiesFilteredQuery(activityFilterRequest, userId);

            if (result == null || result.Activities == null || result.Activities.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("[action]/{userId}/{editionId}")]
        public IActionResult GetFavouriteActivitiesByUser(int userId, int editionId)
        {
            var result = _queries.FavouriteActivitiesByUserQuery(userId, editionId);

            if (result == null || result.Count == 0)
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

        [HttpPost("[action]")]
        public IActionResult EnrollInActivity([FromBody] ActivityEnrollmentRequest request)
        {
            var result = _command.EnrollInActivityCommand(request);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult LeaveActivity([FromBody] ActivityEnrollmentRequest request)
        {
            var result = _command.LeaveActivityCommand(request);

            if (!result)
            {
                return BadRequest(new { message = "Failed to leave activity" });
            }

            return Ok(new { message = "Successfully left activity" });
        }

        [HttpPost("[action]")]
        public IActionResult AddFavouriteActivity([FromBody] ActivityEnrollmentRequest request)
        {
            var result = _command.AddFavouriteActivityCommand(request);

            if (!result)
            {
                return BadRequest(new { message = "Failed to add favourite activity" });
            }

            return Ok(new { message = "Activity added to favourites" });
        }

        [HttpPost("[action]")]
        public IActionResult RemoveFavouriteActivity([FromBody] ActivityEnrollmentRequest request)
        {
            var result = _command.RemoveFavouriteActivityCommand(request);

            if (!result)
            {
                return BadRequest(new { message = "Failed to remove favourite activity" });
            }

            return Ok(new { message = "Activity removed from favourites" });
        }

        [HttpGet("[action]/{activityId}")]
        public IActionResult GetWaitingList(int activityId)
        {
            var result = _queries.GetWaitingListQuery(activityId);

            if (result == null)
            {
                return NotFound(new { message = "Activity not found" });
            }

            return Ok(result);
        }

        [HttpGet("[action]/{activityId}/{userId}")]
        public IActionResult GetUserPositionInWaitingList(int activityId, int userId)
        {
            var position = _queries.GetUserPositionInWaitingListQuery(activityId, userId);

            if (position == null)
            {
                return Ok(new { message = "User not in waiting list", position = (int?)null });
            }

            return Ok(new { message = $"User is at position {position} in waiting list", position });
        }
    }
}
