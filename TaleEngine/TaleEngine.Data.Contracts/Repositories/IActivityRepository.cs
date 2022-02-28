using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface IActivityRepository : IGenericRepository<ActivityEntity>
    {
        List<ActivityEntity> GetEventActivities(int eventId);
        List<ActivityEntity> GetActivitiesByStatus(int edition, int status);
        List<ActivityEntity> GetActiveActivitiesFiltered(int status, int type, int edition, string title, int skip, int activitiesPerPage);
        List<ActivityEntity> GetLastThreeActivities(int status, int edition, int numberOfActivities);
        int GetTotalActivities(int status, int type, int edition, string title);
    }
}
