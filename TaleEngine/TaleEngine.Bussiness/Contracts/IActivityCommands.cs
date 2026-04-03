using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;

namespace TaleEngine.CQRS.Contracts
{
    public interface IActivityCommands
    {
        void DeleteCommand(int activityId);
        void CreateCommand(int editionId, ActivityDto activityDto);
        void UpdateCommand(ActivityDto activityDto);
        void ChangeActivityStatusCommand(int activityId, int statusId);
        ActivityEnrollmentResult EnrollInActivityCommand(ActivityEnrollmentRequest request);
        bool LeaveActivityCommand(ActivityEnrollmentRequest request);
        bool AddFavouriteActivityCommand(ActivityEnrollmentRequest request);
        bool RemoveFavouriteActivityCommand(ActivityEnrollmentRequest request);
    }
}
