using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Dtos.Requests;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("[action]/{editionId}")]
        [MapToApiVersion("1")]
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
        [MapToApiVersion("2")]
        public IActionResult GetPendingActivities(int editionId)
        {
            var result = _activityService.GetPendingActivities(editionId);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("[action]/{editionId}")]
        [MapToApiVersion("1")]
        public IActionResult GetLastThreeActivies(int editionId)
        {
            var result = _activityService.GetLastThreeActivities(editionId);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPut("[action]")]
        [MapToApiVersion("1")]
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
        [MapToApiVersion("2")]
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
        [MapToApiVersion("2")]
        public IActionResult CreateActivity(int editionId, [FromBody] ActivityDto activityDto)
        {
            var authorized = true;

            if (!authorized)
            {
                return NoContent();
            }

            var result = _activityService.CreateActivity(editionId, activityDto);
            return Ok(result);
        }

        [HttpPut("[action]")]
        [MapToApiVersion("2")]
        public IActionResult ChangeActivityStatus([FromBody] ActivityChangeStatusDto activtyChangeStatusDto)
        {
            var result = _activityService.ChangeActivityStatus(activtyChangeStatusDto);

            return Ok(result);
        }

        [HttpPut("[action]")]
        [MapToApiVersion("2")]
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
