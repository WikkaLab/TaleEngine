using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialTimeSlotData
    {
        public static List<TimeSlot> GetTimeSlotData()
        {
            return new List<TimeSlot>
            {
                new TimeSlot { Id = 1, Name = "MON" },
                new TimeSlot { Id = 2, Name = "EVE" },
                new TimeSlot { Id = 3, Name = "NGH" }
            };
        }
    }
}
