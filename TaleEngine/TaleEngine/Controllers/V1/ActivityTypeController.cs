using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ActivityTypeController : Controller
    {
        private readonly IActivityTypeService _activityTypeService;

        public ActivityTypeController(IActivityTypeService activityTypeService)
        {
            _activityTypeService = activityTypeService ?? throw new ArgumentNullException();
        }

        [HttpGet("[action]")]
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
