using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.Dtos;

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

        [HttpGet("[action]")]
        public IActionResult GetActivities()
        {
            var result = _activityService.GetActivities();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpDelete("[action]")]
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

        [HttpPost("[action]")]
        public IActionResult CreateActivity(ActivityDto activityDto)
        {
            var authorized = false;

            if (!authorized)
            {
                return NoContent();
            }

            var result = _activityService.CreateActivity(activityDto);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult UpdateActivity(ActivityDto activityDto)
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
