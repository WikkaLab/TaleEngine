using Microsoft.AspNetCore.Mvc;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventCommands _command;

        public EventController(IEventCommands command)
        {
            _command = command;
        }

        [HttpGet("[action]")]
        public IActionResult GetEvents()
        {
            var result = _command.EventsNoFilterQuery();

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetEvent(int eventId)
        {
            var result = _command.EventQuery(eventId);

            return Ok(result);
        }
    }
}
