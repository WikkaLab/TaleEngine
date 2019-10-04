using System;

namespace TaleEngine.Data.Contracts.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public Guid CreatorId { get; set; }
        public Guid LasModifierId { get; set; }

        public DateTime CreateDateTime { get; set; }
        public DateTime LastModificationDateTime { get; set; }
    }
}
