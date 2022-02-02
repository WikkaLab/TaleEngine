using Microsoft.AspNetCore.Mvc;
using TaleEngine.Commands.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
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
            var result = _command.GetTimeSlots();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
