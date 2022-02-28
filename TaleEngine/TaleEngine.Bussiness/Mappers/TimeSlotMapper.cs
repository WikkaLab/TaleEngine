using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public static class TimeSlotMapper
    {
        public static TimeSlotDto Map(TimeSlotEntity timeslot)
        {
            if (timeslot == null) return null;

            return new TimeSlotDto
            {
                Id = timeslot.Id,
                Name = timeslot.Name
            };
        }

        public static List<TimeSlotDto> Map(List<TimeSlotEntity> timeslots)
        {
            if (timeslots == null || timeslots.Count == 0) return null;

            return timeslots.Select(Map).ToList();
        }
    }
}
