using System.Collections.Generic;
using TaleEngine.Domain.Models;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        int ActivateUser(int userId);
        int DeactivateUser(int userId);
        int BanUser(int userId);
        int ReviewUser(int userId);
        int MarkAsPendingUser(int userId);
    }
}
