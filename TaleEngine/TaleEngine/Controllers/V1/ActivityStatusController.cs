using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ActivityStatusController : Controller
    {
        private readonly IActivityStatusService _activityStatusService;

        public ActivityStatusController(IActivityStatusService activityStatusService)
        {
            _activityStatusService = activityStatusService;
        }

        [HttpGet("[action]")]
        public IActionResult GetActivityStatuses()
        {
            var result = _activityStatusService.GetActivityStatuses();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
