using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<EventEntity> GetAllEvents()
        {
            var events = _unitOfWork.EventRepository.GetAll();

            return events;
        }

        public EventEntity GetById(int eventId)
        {
            var selectedEvent = _unitOfWork.EventRepository.GetById(eventId);
            return selectedEvent;
        }
    }
}