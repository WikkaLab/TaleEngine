using System;
using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class Edition : BaseEntity
    {
        public DateTime DateInit { get; set; }
        public DateTime DateEnd { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
