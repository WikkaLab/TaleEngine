﻿using Microsoft.AspNetCore.Mvc;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class ActivityTypeController : Controller
    {
        private readonly IActivityTypeQueries _command;

        public ActivityTypeController(IActivityTypeQueries command)
        {
            _command = command;
        }

        [HttpGet("[action]")]
        public IActionResult GetActivityTypes()
        {
            var result = _command.AllActivityTypesQuery();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
