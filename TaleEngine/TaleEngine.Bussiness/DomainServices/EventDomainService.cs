using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.Dtos.Mappers;
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

        public List<EventDto> GetEventsNoFilter()
        {
            var events = _unitOfWork.EventRepository.GetAll();

            var eventDtos = new List<EventDto>();

            foreach (var ev in events)
            {
                eventDtos.Add(EventMapper.Map(ev));
            }

            return eventDtos;
        }

        public EventDto GetEvent(int eventId)
        {
            var ev = _unitOfWork.EventRepository.GetById(eventId);

            var result = EventMapper.Map(ev);

            return result;
        }
    }
}
