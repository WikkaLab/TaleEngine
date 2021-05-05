using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Fakes.Dtos;

namespace TaleEngine.Application.Services
{
    [ExcludeFromCodeCoverage]
    public class EventServiceMock : IEventService
    {
        public List<EventDto> GetAllEvents()
        {
            return EventDtoBuilder.BuildEventDtoList();
        }

        public int GetCurrentOrLastEdition(int selectedEvent)
        {
            throw new NotImplementedException();
        }

        public EventDto GetEvent(int eventId)
        {
            return EventDtoBuilder.BuildEventDto();
        }
    }
}