using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class ActivityTypeController : Controller
    {
        private readonly IActivityTypeService _activityTypeService;

        public ActivityTypeController(IActivityTypeService activityTypeService)
        {
            _activityTypeService = activityTypeService;
        }

        [HttpGet("[action]")]
        [MapToApiVersion("1")]
        public IActionResult GetActivityTypes()
        {
            var result = _activityTypeService.GetActivityTypes();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
