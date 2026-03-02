using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [Obsolete("This API version is deprecated. Please use V1 instead.")]
    [ApiController]
    [Route("api/v2/[controller]")]
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotQueries _command;

        public TimeSlotController(ITimeSlotQueries command)
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
