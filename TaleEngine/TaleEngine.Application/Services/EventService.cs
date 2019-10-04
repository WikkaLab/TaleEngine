using System.Collections.Generic;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventDomainService _eventDomainService;

        public EventService(IEventDomainService eventDomainService)
        {
            _eventDomainService = eventDomainService;
        }

        public List<EventDto> GetAllEvents()
        {
            return _eventDomainService.GetEventsNoFilter();
        }
    }
}
