using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.Commands.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ActivityTypeController : Controller
    {
        private readonly IActivityTypeCommands _command;

        public ActivityTypeController(IActivityTypeCommands command)
        {
            _command = command ?? throw new ArgumentNullException();
        }

        [HttpGet("[action]")]
        public IActionResult GetActivityTypes()
        {
            var result = _command.GetActivityTypes();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
