using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TimeSlotService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TimeSlotEntity GetById(int id)
        {
            var timeslot = _unitOfWork.TimeSlotRepository.GetById(id);
            return timeslot;
        }

        public List<TimeSlotEntity> GetTimeSlots()
        {
            var timeSlots = _unitOfWork.TimeSlotRepository.GetAll();
            return timeSlots;
        }
    }
}