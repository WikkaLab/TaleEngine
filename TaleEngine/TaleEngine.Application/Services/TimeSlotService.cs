using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ITimeSlotDomainService _timeSlotDomainService;

        public TimeSlotService(ITimeSlotDomainService timeSlotService)
        {
            _timeSlotDomainService = timeSlotService;
        }

        public List<TimeSlotDto> GetTimeSlots()
        {
            var timeSlots = _timeSlotDomainService.GetAllTimeSlots();

            var result = TimeSlotMapper.Map(timeSlots);

            return result;
        }
    }
}