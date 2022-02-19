using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Enums;

namespace TaleEngine.CQRS.Impl.Backoffice
{
    public class UserStatusCommands : IUserStatusCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserStatusCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int GetActiveStatus()
        {
            var result = GetUserStatus((int)UserStatusEnum.ACTIVE);
            return result;
        }

        public int GetPendingStatus()
        {
            var result = GetUserStatus((int)UserStatusEnum.PENDING);
            return result;
        }

        public int GetBanStatus()
        {
            var result = GetUserStatus((int)UserStatusEnum.BANNED);
            return result;
        }

        public int GetRevisionStatus()
        {
            var result = GetUserStatus((int)UserStatusEnum.REVISION);
            return result;
        }

        public int GetInactiveStatus()
        {
            var result = GetUserStatus((int)UserStatusEnum.INACTIVE);
            return result;
        }

        private int GetUserStatus(int userStatusId)
        {
            if (userStatusId == 0) return 0;

            var result = _unitOfWork.UserStatusRepository
                .GetById(userStatusId);

            return result.Id;
        }
    }
}
