using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialTimeSlotData
    {
        public static List<TimeSlotEntity> GetTimeSlotData()
        {
            return new List<TimeSlotEntity>
            {
                new TimeSlotEntity { Id = 1, Name = "MON" },
                new TimeSlotEntity { Id = 2, Name = "EVE" },
                new TimeSlotEntity { Id = 3, Name = "NGH" }
            };
        }
    }
}
