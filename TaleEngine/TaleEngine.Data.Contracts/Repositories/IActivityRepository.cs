using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface IActivityRepository : IGenericRepository<Activity>
    {
        List<Activity> GetEventActivities(int eventId);
        List<Activity> GetActivitiesByStatus(int edition, int status);
        List<Activity> GetActiveActivitiesFiltered(int status, int type, int edition, string title, int skip);
        int GetTotalActivities(int status, int type, int edition, string title);
    }
}
