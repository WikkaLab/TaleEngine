using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
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
        public IActionResult GetCurrentOrLastEdition(int selectedEvent)
        {
            var result = _eventService.GetCurrentOrLastEdition(selectedEvent);

            return Ok(result);
        }
    }
}
