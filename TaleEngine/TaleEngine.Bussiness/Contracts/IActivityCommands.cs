using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;

namespace TaleEngine.CQRS.Contracts
{
    public interface IActivityCommands
    {
        List<ActivityDto> ActiveActivitiesQuery(int editionId);
        List<ActivityDto> PendingActivitiesQuery(int editionId);
        ActivityFilteredResult ActiveActivitiesFilteredQuery(ActivityFilterRequest activityFilterRequest);
        List<ActivityDto> LastThreeActivitiesQuery(int editionId);

        void DeleteCommand(int activityId);
        void CreateCommand(int editionId, ActivityDto activityDto);
        void UpdateCommand(ActivityDto activityDto);
        void ChangeActivityStatusCommand(int activityId, int statusId);
    }
}
