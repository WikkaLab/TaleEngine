using Microsoft.AspNetCore.Mvc;
using TaleEngine.Commands.Contracts;

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
            var result = _command.GetAllEvents();

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetEvent(int eventId)
        {
            var result = _command.GetEvent(eventId);

            return Ok(result);
        }

        [HttpGet("[action]/{selectedEvent}")]
        public IActionResult GetCurrentOrFutureEdition(int selectedEvent)
        {
            var result = _command.GetCurrentOrFutureEdition(selectedEvent);

            return Ok(result);
        }
    }
}
