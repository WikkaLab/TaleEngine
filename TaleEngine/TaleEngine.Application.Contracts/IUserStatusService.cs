using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface IUserStatusService
    {
        UserStatusEntity GetUserStatus(int statusId);
    }
}
