using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/[controller]")]
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotService _timeSlotService;

        public TimeSlotController(ITimeSlotService timeSlotService)
        {
            _timeSlotService = timeSlotService;
        }

        [HttpGet("[action]")]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        public IActionResult GetTimeSlots()
        {
            var result = _timeSlotService.GetTimeSlots();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
