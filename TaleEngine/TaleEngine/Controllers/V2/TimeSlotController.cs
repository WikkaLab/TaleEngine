using Microsoft.AspNetCore.Mvc;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotCommands _command;

        public TimeSlotController(ITimeSlotCommands command)
        {
            _command = command;
        }

        [HttpGet("[action]")]
        public IActionResult GetTimeSlots()
        {
            var result = _command.AllTimeSlotsQuery();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
