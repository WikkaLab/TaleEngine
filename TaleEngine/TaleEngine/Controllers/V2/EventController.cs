using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [Obsolete("This API version is deprecated. Please use V1 instead.")]
    [ApiController]
    [Route("api/v2/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventQueries _command;

        public EventController(IEventQueries eventService)
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
            var result = _command.GetEvent(eventId);

            return Ok(result);
        }
    }
}
