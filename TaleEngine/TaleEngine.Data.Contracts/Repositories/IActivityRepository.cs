using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface IActivityRepository : IGenericRepository<Activity>
    {
        List<Activity> GetEventActivities(int eventId);
    }
}
