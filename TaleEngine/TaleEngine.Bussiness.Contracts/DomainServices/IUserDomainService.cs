using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Bussiness.Contracts.DomainServices
{
    public interface IUserDomainService
    {
        List<UserModel> GetAllUsers();
    }
}
