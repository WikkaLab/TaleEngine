using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class EventEntity : BaseEntity
    {
        public string Title { get; set; }

        public List<EditionEntity> Editions { get; set; }
        public List<RoleEntity> Roles { get; set; }
    }
}
