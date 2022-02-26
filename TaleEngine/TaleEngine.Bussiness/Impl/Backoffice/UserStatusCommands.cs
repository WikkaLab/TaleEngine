using TaleEngine.CQRS.Contracts;
using TaleEngine.Cross.Enums;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.CQRS.Impl.Backoffice
{
    public class UserStatusCommands : IUserStatusCommands
    {
        private readonly IUserStatusService _service;

        public UserStatusCommands(IUserStatusService service)
        {
            _service = service;
        }

        public int ActiveQuery()
        {
            var result = GetUserStatus((int)UserStatusEnum.ACTIVE);
            return result;
        }

        public int PendingQuery()
        {
            var result = GetUserStatus((int)UserStatusEnum.PENDING);
            return result;
        }

        public int BanQuery()
        {
            var result = GetUserStatus((int)UserStatusEnum.BANNED);
            return result;
        }

        public int RevisionQuery()
        {
            var result = GetUserStatus((int)UserStatusEnum.REVISION);
            return result;
        }

        public int InactiveQuery()
        {
            var result = GetUserStatus((int)UserStatusEnum.INACTIVE);
            return result;
        }

        private int GetUserStatus(int userStatusId)
        {
            if (userStatusId == 0) return 0;

            var result = _service.GetUserStatus(userStatusId);

            return result.Id;
        }
    }
}
