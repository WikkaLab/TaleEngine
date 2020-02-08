using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts;

namespace TaleEngine.Bussiness.DomainServices
{
    public class TimeSlotDomainService : ITimeSlotDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TimeSlotDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TimeSlotModel> GetAllTimeSlots()
        {
            var timeslots = _unitOfWork.TimeSlotRepository.GetAll();

            var timeslotDtos = new List<TimeSlotModel>();

            foreach (var type in timeslots)
            {
                timeslotDtos.Add(TimeSlotMapper.Map(type));
            }

            return timeslotDtos;
        }
    }
}
