using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Dtos.Requests;
using TaleEngine.Application.Contracts.Dtos.Results;

namespace TaleEngine.Application.Contracts.Services
{
    public interface IActivityService
    {
        List<ActivityDto> GetActiveActivities(int editionId);
        List<ActivityDto> GetPendingActivities(int editionId);
        ActivityFilteredResult GetActiveActivitiesFiltered(ActivityFilterRequest activityFilterRequest);
        int DeleteActivity(int activityId);
        int CreateActivity(int editionId, ActivityDto activityDto);
        int UpdateActivity(ActivityDto activityDto);

        int ChangeActivityStatus(ActivityChangeStatusDto activityChangeStatusDto);
        List<ActivityDto> GetLastThreeActivities(int editionId);
    }
}
