using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IActivityCommands
    {
        void DeleteCommand(int activityId);
        void CreateCommand(int editionId, ActivityDto activityDto);
        void UpdateCommand(ActivityDto activityDto);
        void ChangeActivityStatusCommand(int activityId, int statusId);
    }
}
