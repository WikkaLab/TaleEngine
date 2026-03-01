using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace TaleEngine.Data.Contracts.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateTime { get; set; }
        public DateTime? ModificationDate { get; set; }

        public bool IsDeleted { get; set; } = false;

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

            ModificationDate = now;
        }
    }
}
