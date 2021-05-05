using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Fakes.Dtos;

namespace TaleEngine.Application.Services
{
    [ExcludeFromCodeCoverage]
    public class TimeSlotServiceMock : ITimeSlotService
    {
        public List<TimeSlotDto> GetTimeSlots()
        {
            return TimeSlotDtoBuilder.BuildTimeSlotDtoList();
        }
    }
}