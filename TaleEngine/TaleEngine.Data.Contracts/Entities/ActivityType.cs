using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class ActivityType : BaseEntity
    {
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Description { get; set; }


        public List<Activity> Activities { get; set; }
    }
}
