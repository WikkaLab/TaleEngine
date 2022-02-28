using Microsoft.AspNetCore.Mvc;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class ActivityStatusController : Controller
    {
        private readonly IActivityStatusCommands _command;

        public ActivityStatusController(IActivityStatusCommands command)
        {
            _command = command;
        }

        [HttpGet("[action]")]
        public IActionResult GetActivityStatuses()
        {
            var result = _command.AllActivityStatusQuery();

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
