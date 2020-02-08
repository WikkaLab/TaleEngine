using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.Models.Results;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Bussiness.Contracts.DomainServices
{
    public interface IActivityDomainService
    {                                                         
        List<ActivityModel> GetActiveActivities(int editionId);
        List<ActivityModel> GetPendingActivities(int editionId);
        ActivityFilteredResultModel GetActiveActivitiesFiltered(int type, int edition, string title, int currentPage);
        int DeleteActivity(int activityId);
        int CreateActivity(int editionId, ActivityModel activityDto);
        int UpdateActivity(ActivityModel activityDto);

        int ChangeActivityStatus(int activityId, int statusId);
    }
}
