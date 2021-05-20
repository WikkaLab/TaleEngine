using System.Collections.Generic;
using System.Linq;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public static class TimeSlotMapper
    {
        public static TimeSlotDto Map(TimeSlotModel timeslot)
        {
            if (timeslot == null) return null;

            return new TimeSlotDto
            {
                Id = timeslot.Id,
                Name = timeslot.Name
            };
        }

        public static List<TimeSlotDto> Map(List<TimeSlotModel> timeslots)
        {
            if (timeslots == null || timeslots.Count == 0) return null;

            return timeslots.Select(Map).ToList();
        }

        public static TimeSlotModel Map(TimeSlotDto timeslotDto)
        {
            if (timeslotDto == null) return null;

            return new TimeSlotModel
            {
                Id = timeslotDto.Id,
                Name = timeslotDto.Name
            };
        }

        public static List<TimeSlotModel> Map(List<TimeSlotDto> timeslotDto)
        {
            if (timeslotDto == null) return null;

            return timeslotDto.Select(Map).ToList();
        }
    }
}
