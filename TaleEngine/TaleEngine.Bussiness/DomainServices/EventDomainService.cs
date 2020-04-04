using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts;

namespace TaleEngine.Bussiness.DomainServices
{
    public class EventDomainService : IEventDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<EventModel> GetEventsNoFilter()
        {
            var events = _unitOfWork.EventRepository.GetAll();

            var eventDtos = new List<EventModel>();

            foreach (var ev in events)
            {
                eventDtos.Add(EventMapper.Map(ev));
            }

            return eventDtos;
        }

        public EventModel GetEvent(int eventId)
        {
            var ev = _unitOfWork.EventRepository.GetById(eventId);

            var result = EventMapper.Map(ev);

            return result;
        }
    }
}
