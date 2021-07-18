using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("[action]")]
        public IActionResult GetEvents()
        {
            var result = _eventService.GetAllEvents();

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetEvent(int eventId)
        {
            var result = _eventService.GetEvent(eventId);

            return Ok(result);
        }

        [HttpGet("[action]/{selectedEvent}")]
        public IActionResult GetCurrentOrFutureEdition(int selectedEvent)
        {
            var result = _eventService.GetCurrentOrFutureEdition(selectedEvent);

            return Ok(result);
        }
    }
}
