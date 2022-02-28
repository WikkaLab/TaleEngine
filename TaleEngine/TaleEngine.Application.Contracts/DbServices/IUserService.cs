using System.Collections.Generic;
using TaleEngine.Aggregates.UserAggregate;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IUserService
    {
        UserEntity GetById(int id);
        List<UserEntity> GetAllUsers();
        void ChangeUserStatus(int id, User user);
    }
}
