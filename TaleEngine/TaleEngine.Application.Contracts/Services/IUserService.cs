using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;

namespace TaleEngine.Application.Contracts.Services
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();
        int ActivateUser(int userId);
        int DeactivateUser(int userId);
        int BanUser(int userId);
        int ReviewUser(int userId);
        int MarkAsPendingUser(int userId);
    }
}
