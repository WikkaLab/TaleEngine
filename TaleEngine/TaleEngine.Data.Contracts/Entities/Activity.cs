using System;

namespace TaleEngine.Data.Contracts.Entities
{
    public class Activity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public int Places { get; set; }

        public int StatusId { get; set; }
        public ActivityStatus Status { get; set; }
        public int TypeId { get; set; }
        public ActivityType Type { get; set; }

        public Guid CreatorId { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
