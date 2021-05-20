using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Mappers;
using TaleEngine.Bussiness.Contracts.DomainServices;

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
            var timeSlots = _timeSlotDomainService.GetAllTimeSlots();

            var result = TimeSlotMapper.Map(timeSlots);

            return result;
        }
    }
}