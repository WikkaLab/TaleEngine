using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("[action]")]
        public IList<EventDto> GetEvents()
        {
            return _eventService.GetAllEvents();
        }
    }
}
