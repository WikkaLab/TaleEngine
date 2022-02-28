using Microsoft.EntityFrameworkCore;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts
{
    public interface IDatabaseContext
    {
        DbSet<EventEntity> Events { get; set; }
        DbSet<ActivityEntity> Activities { get; set; }
        DbSet<ActivityTypeEntity> ActivityTypes { get; set; }
        DbSet<ActivityStatusEntity> ActivityStatuses { get; set; }
        DbSet<UserStatusEntity> UserStatuses { get; set; }
        DbSet<UserEntity> Users { get; set; }
        DbSet<PermissionEntity> Permissions { get; set; }
        DbSet<PermissionValueEntity> PermissionsValue { get; set; }
        DbSet<AssignedPermissionEntity> AssignedPermissions { get; set; }
        DbSet<RoleEntity> Roles { get; set; }
        DbSet<EditionEntity> Editions { get; set; }
        DbSet<TimeSlotEntity> TimeSlots { get; set; }

        int SaveChanges();
    }
}
