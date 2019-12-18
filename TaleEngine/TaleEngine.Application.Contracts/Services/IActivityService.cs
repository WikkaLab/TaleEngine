using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Dtos.Requests;

namespace TaleEngine.Application.Contracts.Services
{
    public interface IActivityService
    {
        List<ActivityDto> GetActiveActivities(int editionId);
        List<ActivityDto> GetPendingActivities(int editionId);
        List<ActivityDto> GetActiveActivitiesFiltered(ActivityFilterRequest activityFilterRequest);
        int DeleteActivity(int activityId);
        int CreateActivity(int editionId, ActivityDto activityDto);
        int UpdateActivity(ActivityDto activityDto);

        int ChangeActivityStatus(ActivityChangeStatusDto activityChangeStatusDto);
    }
}
