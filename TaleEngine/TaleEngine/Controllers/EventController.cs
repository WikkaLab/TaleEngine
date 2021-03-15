using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("[action]")]
        [MapToApiVersion("1")]
        public IActionResult GetEvents()
        {
            var result = _eventService.GetAllEvents();

            return Ok(result);
        }

        [HttpGet("[action]")]
        [MapToApiVersion("1")]
        public IActionResult GetEvent(int eventId)
        {
            var result = _eventService.GetEvent(eventId);

            return Ok(result);
        }

        [HttpGet("[action]/{selectedEvent}")]
        [MapToApiVersion("1")]
        public IActionResult GetCurrentOrLastEdition(int selectedEvent)
        {
            var result = _eventService.GetCurrentOrLastEdition(selectedEvent);

            return Ok(result);
        }
    }
}
