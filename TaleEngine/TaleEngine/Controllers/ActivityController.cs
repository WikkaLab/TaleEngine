using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Dtos.Requests;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("[action]/{editionId}")]
        [ProducesResponseType(typeof(List<ActivityDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        public IActionResult GetActivities(int editionId)
        {
            var result = _activityService.GetActiveActivities(editionId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("[action]/{editionId}")]
        [HttpGet("[action]/{editionId}")]
        [ProducesResponseType(typeof(List<ActivityDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        public IActionResult GetPendingActivities(int editionId)
        {
            var result = _activityService.GetPendingActivities(editionId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPut("[action]")]
        [HttpGet("[action]/{editionId}")]
        [ProducesResponseType(typeof(ActivityFilteredResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        public IActionResult GetActivitiesFiltered([FromBody] ActivityFilterRequest activityFilterRequest)
        {
            var result = _activityService.GetActiveActivitiesFiltered(activityFilterRequest);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpDelete("[action]/{activityId}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        public IActionResult DeleteActivity(int activityId)
        {
            var authorized = false;

            if (!authorized)
            {
                return Unauthorized();
            }

            var result = _activityService.DeleteActivity(activityId);
            return Ok(result);
        }

        [HttpPost("[action]/{editionId}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        public IActionResult CreateActivity(int editionId, [FromBody] ActivityDto activityDto)
        {
            var authorized = true;

            if (!authorized)
            {
                return Unauthorized();
            }

            var result = _activityService.CreateActivity(editionId, activityDto);
            return Ok(result);
        }

        [HttpPut("[action]")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public IActionResult ChangeActivityStatus([FromBody] ActivityChangeStatusDto activtyChangeStatusDto)
        {
            var result = _activityService.ChangeActivityStatus(activtyChangeStatusDto);

            return Ok(result);
        }

        [HttpPut("[action]")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public IActionResult UpdateActivity([FromBody] ActivityDto activityDto)
        {
            var authorized = false;

            if (!authorized)
            {
                return Unauthorized();
            }

            var result = _activityService.UpdateActivity(activityDto);
            return Ok(result);
        }
    }
}
