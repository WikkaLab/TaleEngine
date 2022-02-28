using System;

namespace TaleEngine.Aggregates.EventAggregate
{
    public class Edition
    {
        public int Id { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateEnd { get; set; }

        public int EventId { get; set; }
    }
}
