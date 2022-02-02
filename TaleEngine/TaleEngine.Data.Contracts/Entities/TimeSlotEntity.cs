using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class TimeSlotEntity : BaseEntity
    {
        public string Name { get; set; }

        public List<ActivityEntity> Activities { get; set; }
    }
}
