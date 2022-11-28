using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotQueries _command;

        public TimeSlotController(ITimeSlotQueries command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
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
