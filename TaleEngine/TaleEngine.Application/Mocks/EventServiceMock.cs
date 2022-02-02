using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.DbServices.Contracts.Services;
using TaleEngine.Fakes.Dtos;

namespace TaleEngine.DbServices.Mocks
{
    [ExcludeFromCodeCoverage]
    public class EventServiceMock : IEventService
    {
        public List<EventDto> GetAllEvents()
        {
            return EventDtoBuilder.BuildEventDtoList();
        }

        public int GetCurrentOrFutureEdition(int selectedEvent)
        {
            throw new NotImplementedException();
        }

        public EventDto GetEvent(int eventId)
        {
            return EventDtoBuilder.BuildEventDto();
        }
    }
}