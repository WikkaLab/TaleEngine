using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Bussiness.DomainServices
{
    public class EventDomainService : IEventDomainService
    {
        private readonly IEventRepository _eventRepository;

        public EventDomainService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        public List<EventModel> GetEventsNoFilter()
        {
            var events = _eventRepository.GetAll();

            var eventDtos = new List<EventModel>();

            foreach (var ev in events)
            {
                eventDtos.Add(EventMapper.Map(ev));
            }

            return eventDtos;
        }

        public EventModel GetEvent(int eventId)
        {
            var ev = _eventRepository.GetById(eventId);

            var result = EventMapper.Map(ev);

            return result;
        }
    }
}