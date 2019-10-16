using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class TimeSlot : BaseEntity
    {
        public string Name { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
