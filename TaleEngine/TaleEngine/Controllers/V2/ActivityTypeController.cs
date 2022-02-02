using Microsoft.AspNetCore.Mvc;
using TaleEngine.Commands.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class ActivityTypeController : Controller
    {
        private readonly IActivityTypeCommands _command;

        public ActivityTypeController(IActivityTypeCommands command)
        {
            _command = command;
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
