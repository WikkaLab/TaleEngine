using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Bussiness.Contracts.DomainServices
{
    public interface IUserDomainService
    {
        List<UserModel> GetAllUsers();
        UserModel GetUser(int userId);
        int ActivateUser(int userId);
        int DeactivateUser(int userId);
        int BanUser(int userId);
        int ReviewUser(int userId);
        int MarkAsPendingUser(int userId);
    }
}
