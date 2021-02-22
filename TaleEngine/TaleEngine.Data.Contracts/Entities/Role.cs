using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Description { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public List<User> Users { get; set; }
    }
}
