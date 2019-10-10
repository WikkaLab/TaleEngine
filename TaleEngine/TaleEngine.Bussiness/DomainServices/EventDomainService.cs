using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.Dtos;
using TaleEngine.Bussiness.Dtos.Mappers;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Bussiness.DomainServices
{
    public class EventDomainService : IEventDomainService
    {
        private readonly IEventRepository _eventRepository;

        public EventDomainService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<EventDto> GetEventsNoFilter()
        {
            var events = _eventRepository.GetAll();

            var eventDtos = new List<EventDto>();

            foreach (var ev in events)
            {
                eventDtos.Add(EventMapper.Map(ev));
            }

            return eventDtos;
        }
    }
}
