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
        IEnumerable<ActivityEntity> GetActiveActivitiesFiltered(int typeId, int editionId, List<int> timeframes, string title, int skipByPagination, int activitiesPerPage, int userFav = default);

        int ChangeActivityStatus(int activityId, int statusId);
        int DeleteActivity(int activityId);
        int CreateActivity(int editionId, Activity activity);
        int UpdateActivity(int id, Activity activity);

        // Waiting List methods
        bool EnrollUserInActivity(int activityId, int userId);
        bool RemoveUserFromActivity(int activityId, int userId);
        List<UserEntity> GetWaitingList(int activityId);
        int? GetUserPositionInWaitingList(int activityId, int userId);
        bool PromoteFromWaitingList(int activityId);
    }
}
