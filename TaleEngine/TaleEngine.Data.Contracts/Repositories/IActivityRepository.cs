using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.SeedWork;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface IActivityRepository : IGenericRepository<Activity>
    {
        List<Activity> GetEventActivities(int eventId);

        List<Activity> GetActivitiesByStatus(int edition, int status);

        List<Activity> GetActiveActivitiesFiltered(int status, int type, int edition, string title, int skip, int activitiesPerPage);

        List<Activity> GetLastThreeActivities(int status, int edition, int numberOfActivities);

        int GetTotalActivities(int status, int type, int edition, string title);
    }
}