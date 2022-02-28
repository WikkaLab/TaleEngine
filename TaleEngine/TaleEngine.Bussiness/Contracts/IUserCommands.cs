using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IUserCommands
    {
        List<UserDto> AllUsersQuery();
        UserDto UserQuery(int userId);

        void ActivateCommand(int userId);
        void DeactivateCommand(int userId);
        void BanCommand(int userId);
        void ReviewCommand(int userId);
        void MarkAsPendingCommand(int userId);
    }
}
