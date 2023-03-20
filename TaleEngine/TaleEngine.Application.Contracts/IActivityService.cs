using System.Collections.Generic;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface IActivityService
    {
        ActivityEntity GetById(int id);
        List<ActivityEntity> GetActiveActivities(int editionId);
        List<ActivityEntity> GetPendingActivities(int editionId);
        List<ActivityEntity> GetLastThreeActivities(int editionId);
        List<ActivityEntity> GetActiveActivitiesFiltered(int typeId, int editionId,
                        List<int> timeframes, string title, int skipByPagination, int activitiesPerPage);
        int GetTotalActiveActivities(int typeId, int editionId, List<int> timeframes, string title);

        int ChangeActivityStatus(int activityId, int statusId);
        int DeleteActivity(int activityId);
        int CreateActivity(int editionId, Activity activity);
        int UpdateActivity(int id, Activity activity);

    }
}
