using System.Collections.Generic;
using TaleEngine.Commands.Contracts;

namespace TaleEngine.Commands.Impl
{
    public class EventCommands : IEventCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventCommands(IUnitOfWork unitOfWork)
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