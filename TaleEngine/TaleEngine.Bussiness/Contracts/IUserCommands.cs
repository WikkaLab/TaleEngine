using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IUserCommands
    {
        UserDto RegisterCommand(UserDto user);
        void UpdateProfileCommand(int userId, UserDto user);
        void ActivateCommand(int userId);
        void DeactivateCommand(int userId);
        void BanCommand(int userId);
        void ReviewCommand(int userId);
        void MarkAsPendingCommand(int userId);
        void AssignRoleCommand(int userId, int roleId);
    }
}
