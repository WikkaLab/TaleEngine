using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Commands.Mappers
{
    public static class TimeSlotMapper
    {
        public static TimeSlotEntity Map(TimeSlotModel timeslotModel)
        {
            if (timeslotModel == null) return null;

            return new TimeSlotEntity
            {
                Id = timeslotModel.Id,
                Name = timeslotModel.Name
            };
        }

        public static List<TimeSlotEntity> Map(List<TimeSlotModel> timeslotModels)
        {
            if (timeslotModels == null || timeslotModels.Count == 0) return null;

            return timeslotModels.Select(Map).ToList();
        }

        public static TimeSlotModel Map(TimeSlotEntity timeslot)
        {
            if (timeslot == null) return null;

            return new TimeSlotModel
            {
                Id = timeslot.Id,
                Name = timeslot.Name
            };
        }

        public static List<TimeSlotModel> Map(List<TimeSlotEntity> timeslots)
        {
            if (timeslots == null || timeslots.Count == 0) return null;

            return timeslots.Select(Map).ToList();
        }
    }
}
