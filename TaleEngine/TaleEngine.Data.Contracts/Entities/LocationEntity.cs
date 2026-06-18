using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class LocationEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }

        public int EditionId { get; set; }
        public EditionEntity Edition { get; set; }

        public List<ActivityEntity> Activities { get; set; }
    }
}
