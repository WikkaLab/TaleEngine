using System.Collections.Generic;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Application.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly ITimeSlotDomainService _timeSlotDomainService;

        public TimeSlotService(ITimeSlotDomainService timeSlotService)
        {
            _timeSlotDomainService = timeSlotService;
        }

        public List<TimeSlotDto> GetTimeSlots()
        {
            return _timeSlotDomainService.GetAllTimeSlots();
        }
    }
}
