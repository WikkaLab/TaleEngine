using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;

namespace TaleEngine.CQRS.Contracts
{
    public interface IActivityQueries
    {
        List<ActivityDto> ActiveActivitiesQuery(int editionId);
        List<ActivityDto> PendingActivitiesQuery(int editionId);
        ActivityFilteredResult ActiveActivitiesFilteredQuery(ActivityFilterRequest activityFilterRequest, int userId = default);
        List<ActivityDto> LastThreeActivitiesQuery(int editionId);
    }
}
