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

        int SaveChanges();
    }
}
