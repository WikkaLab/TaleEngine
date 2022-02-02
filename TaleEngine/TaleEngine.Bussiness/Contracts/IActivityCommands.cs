using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;

namespace TaleEngine.Commands.Contracts
{
    public interface IActivityCommands
    {
        List<ActivityDto> ActiveActivitiesQuery(int editionId);
        List<ActivityDto> PendingActivitiesQuery(int editionId);
        ActivityFilteredResult ActiveActivitiesFilteredQuery(ActivityFilterRequest activityFilterRequest);
        List<ActivityDto> LastThreeActivitiesQuery(int editionId);

        int DeleteCommand(int activityId);
        int CreateCommand(int editionId, ActivityDto activityDto);
        int UpdateCommand(ActivityDto activityDto);
        int ChangeActivityStatusCommand(int activityId, int statusId);
    }
}
