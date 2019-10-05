using System;

namespace TaleEngine.Data.Contracts.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public Guid CreateUserId { get; set; }
        public Guid LasModificationUserId { get; set; }

        public DateTime CreateDateTime { get; set; }
        public DateTime LastModificationDateTime { get; set; }
    }
}
