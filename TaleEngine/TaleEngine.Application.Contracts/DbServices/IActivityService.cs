using System.Collections.Generic;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IActivityService
    {
        Activity GetById(int id);
        List<ActivityEntity> GetActiveActivities(int editionId);
        List<ActivityEntity> GetPendingActivities(int editionId);
        List<ActivityEntity> GetLastThreeActivities(int editionId);
        List<ActivityEntity> GetActiveActivitiesFiltered(int typeId, int editionId,
                        string title, int skipByPagination, int activitiesPerPage);

        int ChangeActivityStatus(int activityId, int statusId);
        int DeleteActivity(int activityId);
        int CreateActivity(int editionId, Activity activity);
        int UpdateActivity(Activity activity);

    }
}
