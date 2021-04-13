using System.Collections.Generic;
using System.Linq;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class TimeSlotMapper
    {
        public static TimeSlot Map(TimeSlotModel timeslotModel)
        {
            if (timeslotModel == null) return null;

            return new TimeSlot
            {
                Id = timeslotModel.Id,
                Name = timeslotModel.Name
            };
        }

        public static List<TimeSlot> Map(List<TimeSlotModel> timeslotModels)
        {
            if (timeslotModels == null || timeslotModels.Count == 0) return null;

            return timeslotModels.Select(Map).ToList();
        }

        public static TimeSlotModel Map(TimeSlot timeslot)
        {
            if (timeslot == null) return null;

            return new TimeSlotModel
            {
                Id = timeslot.Id,
                Name = timeslot.Name
            };
        }

        public static List<TimeSlotModel> Map(List<TimeSlot> timeslots)
        {
            if (timeslots == null || timeslots.Count == 0) return null;

            return timeslots.Select(Map).ToList();
        }
    }
}
