using Microsoft.AspNetCore.Mvc;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventCommands _command;

        public EventController(IEventCommands eventService)
        {
            _command = eventService;
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
