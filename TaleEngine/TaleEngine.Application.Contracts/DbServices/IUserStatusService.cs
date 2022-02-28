using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IUserStatusService
    {
        UserStatusEntity GetUserStatus(int statusId);
    }
}
