using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Description { get; set; }

        public int? EventId { get; set; }
        public EventEntity Event { get; set; }

        public List<UserEntity> Users { get; set; }
    }
}
