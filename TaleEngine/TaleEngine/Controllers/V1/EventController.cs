using Microsoft.AspNetCore.Mvc;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventQueries _command;

        public EventController(IEventQueries command)
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
