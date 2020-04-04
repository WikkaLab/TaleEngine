using System.Collections.Generic;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Mappers;
using System;

namespace TaleEngine.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventDomainService _eventDomainService;
        private readonly IEditionService _editionService;

        public EventService(IEventDomainService eventDomainService,
            IEditionService editionService)
        {
            _eventDomainService = eventDomainService ?? throw new ArgumentNullException(nameof(eventDomainService));
            _editionService = editionService ?? throw new ArgumentNullException(nameof(editionService));
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

        public int GetCurrentOrLastEdition(int selectedEvent)
        {
            int lastOrCurrentEdition = _editionService.GetCurrentOrLastEdition(selectedEvent);
            return lastOrCurrentEdition;
        }

        public EventDto GetEvent(int eventId)
        {
            var selectedEvent = _eventDomainService.GetEvent(eventId);
            return EventMapper.Map(selectedEvent);
        }

    }
}
