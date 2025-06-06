﻿using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class EventQueries : IEventQueries
    {
        private readonly IEventService _service;

        public EventQueries(IEventService service)
        {
            _service = service;
        }

        public List<EventDto> EventsNoFilterQuery()
        {
            var events = _service.GetAllEvents();

            var eventDtos = new List<EventDto>();

            foreach (var ev in events)
            {
                eventDtos.Add(EventMapper.Map(ev));
            }

            return eventDtos;
        }

        public EventDto GetEvent(int eventId)
        {
            var ev = _service.GetById(eventId);

            var result = EventMapper.Map(ev);

            return result;
        }

        public EditionInEventDto GetCurrentEdition(int eventId) {
            var ev = _service.GetById(eventId);

            var result = EventMapper.MapWithCurrentEdition(ev);

            return result;
        }
    }
}