using System.Collections.Generic;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Mappers;

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
            var events = _eventDomainService.GetEventsNoFilter();

            var result = new List<EventDto>();

            foreach (var ev in events)
            {
                result.Add(EventMapper.Map(ev));
            }

            return result;
        }

        public EventDto GetEvent(int eventId)
        {
            var selectedEvent = _eventDomainService.GetEvent(eventId);

            return EventMapper.Map(selectedEvent);
        }
    }
}
