using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Dtos.Results;

namespace TaleEngine.Bussiness.Contracts.DomainServices
{
    public interface IActivityDomainService
    {                                                         
        List<ActivityDto> GetActiveActivities(int editionId);
        List<ActivityDto> GetPendingActivities(int editionId);
        ActivityFilteredResult GetActiveActivitiesFiltered(int type, int edition, string title, int currentPage);
        int DeleteActivity(int activityId);
        int CreateActivity(int editionId, ActivityDto activityDto);
        int UpdateActivity(ActivityDto activityDto);

        int ChangeActivityStatus(int activityId, int statusId);
    }
}
