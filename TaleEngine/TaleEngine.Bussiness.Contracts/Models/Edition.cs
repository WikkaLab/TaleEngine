using System;

namespace TaleEngine.Domain.Models
{
    public class Edition
    {
        public int Id { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateEnd { get; set; }

        public int EventId { get; set; }
    }
}
