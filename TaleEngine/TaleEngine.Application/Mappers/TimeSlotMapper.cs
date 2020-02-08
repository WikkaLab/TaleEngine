using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public static class TimeSlotMapper
    {
        public static TimeSlotDto Map(TimeSlotModel timeslot)
        {
            return new TimeSlotDto
            {
                Id = timeslot.Id,
                Name = timeslot.Name
            };
        }

        public static TimeSlotModel Map(TimeSlotDto timeslotDto)
        {
            return new TimeSlotModel
            {
                Id = timeslotDto.Id,
                Name = timeslotDto.Name
            };
        }
    }
}
