using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ActivityTypeController : Controller
    {
        private readonly IActivityTypeQueries _command;

        public ActivityTypeController(IActivityTypeQueries command)
        {
            _command = command ?? throw new ArgumentNullException();
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
