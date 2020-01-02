using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Dtos.Requests;

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
        public IActionResult GetActivitiesFiltered([FromBody] ActivityFilterRequest activityFilterRequest)
        {
            var result = _activityService.GetActiveActivitiesFiltered(activityFilterRequest);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpDelete("[action]/{activityId}")]
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
        public IActionResult ChangeActivityStatus([FromBody] ActivityChangeStatusDto activtyChangeStatusDto)
        {
            var result = _activityService.ChangeActivityStatus(activtyChangeStatusDto);

            return Ok(result);
        }

        [HttpPut("[action]")]
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
