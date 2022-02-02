using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

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

            var result = EventMapper.Map(events);

            return result;
        }

        public int GetCurrentOrFutureEdition(int selectedEvent)
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