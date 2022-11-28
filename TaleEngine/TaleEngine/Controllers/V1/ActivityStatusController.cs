using Microsoft.AspNetCore.Mvc;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ActivityStatusController : Controller
    {
        private readonly IActivityStatusQueries _command;

        public ActivityStatusController(IActivityStatusQueries command)
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
