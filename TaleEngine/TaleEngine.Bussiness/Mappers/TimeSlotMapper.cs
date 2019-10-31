using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class TimeSlotMapper
    {
        public static TimeSlotDto Map(TimeSlot timeslot)
        {
            return new TimeSlotDto
            {
                Id = timeslot.Id,
                Name = timeslot.Name
            };
        }

        public static TimeSlot Map(TimeSlotDto timeslotDto)
        {
            return new TimeSlot
            {
                Id = timeslotDto.Id,
                Name = timeslotDto.Name
            };
        }
    }
}
