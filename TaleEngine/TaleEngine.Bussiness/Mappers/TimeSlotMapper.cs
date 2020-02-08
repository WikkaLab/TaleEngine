using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class TimeSlotMapper
    {
        public static TimeSlot Map(TimeSlotModel timeslotModel)
        {
            return new TimeSlot
            {
                Id = timeslotModel.Id,
                Name = timeslotModel.Name
            };
        }

        public static TimeSlotModel Map(TimeSlot timeslot)
        {
            return new TimeSlotModel
            {
                Id = timeslot.Id,
                Name = timeslot.Name
            };
        }
    }
}
