using System;
using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class EditionEntity : BaseEntity
    {
        public DateTime DateInit { get; set; }
        public DateTime DateEnd { get; set; }

        public int EventId { get; set; }
        public EventEntity Event { get; set; }

        public List<ActivityEntity> Activities { get; set; }
    }
}
