using Microsoft.AspNetCore.Mvc;
using TaleEngine.Commands.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ActivityStatusController : Controller
    {
        private readonly IActivityCommands _command;

        public ActivityStatusController(IActivityCommands command)
        {
            _command = command;
        }

        [HttpGet("[action]")]
        public IActionResult GetActivityStatuses()
        {
            var result = _command.GetActivityStatuses();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
