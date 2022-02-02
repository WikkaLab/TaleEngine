using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.Commands.Contracts
{
    public interface IUserCommands
    {
        List<UserDto> AllUsersQuery();
        UserDto UserQuery(int userId);

        int ActivateCommand(int userId);
        int DeactivateCommand(int userId);
        int BanCommand(int userId);
        int ReviewCommand(int userId);
        int MarkAsPendingCommand(int userId);
    }
}
