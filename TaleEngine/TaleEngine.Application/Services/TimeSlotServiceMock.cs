using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Fakes.Dtos;

namespace TaleEngine.Application.Services
{
    public class TimeSlotServiceMock : ITimeSlotService
    {
        public TimeSlotServiceMock()
        {
        }

        public List<TimeSlotDto> GetTimeSlots()
        {
            return TimeSlotDtoBuilder.BuildTimeSlotDtoList();
        }
    }
}