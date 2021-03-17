using Microsoft.EntityFrameworkCore;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts
{
    public interface IDatabaseContext
    {
        DbSet<Event> Events { get; set; }
        DbSet<Activity> Activities { get; set; }
        DbSet<ActivityType> ActivityTypes { get; set; }
        DbSet<ActivityStatus> ActivityStatuses { get; set; }
        DbSet<UserStatus> UserStatuses { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<PermissionValue> PermissionsValue { get; set; }
        DbSet<AssignedPermission> AssignedPermissions { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Edition> Editions { get; set; }
        DbSet<TimeSlot> TimeSlot { get; set; }

        int SaveChanges();
    }
}
