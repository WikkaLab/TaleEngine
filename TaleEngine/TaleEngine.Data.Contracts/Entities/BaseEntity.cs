using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace TaleEngine.Data.Contracts.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public Guid? CreateUserId { get; set; }
        public Guid? LasModificationUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }
        public DateTime? LastModificationDateTime { get; set; }

        public void SetAudit(EntityState state)
        {
            var now = DateTime.UtcNow;
            if (state == EntityState.Added)
            {
                if (CreateDateTime == default(DateTime))
                {
                    CreateDateTime = now;
                }
            }

            LastModificationDateTime = now;
        }
    }
}
