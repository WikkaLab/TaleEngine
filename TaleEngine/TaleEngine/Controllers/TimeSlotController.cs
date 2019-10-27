﻿using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers
{
    [Route("api/[controller]")]
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotService _timeSlotService;

        public TimeSlotController(ITimeSlotService timeSlotService)
        {
            _timeSlotService = timeSlotService;
        }

        [HttpGet("[action]")]
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
