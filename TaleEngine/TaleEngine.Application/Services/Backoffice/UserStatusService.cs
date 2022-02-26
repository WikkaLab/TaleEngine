using System;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services.Backoffice
{
    public class UserStatusService : IUserStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public UserStatusEntity GetUserStatus(int statusId)
        {
            var result = _unitOfWork.UserStatusRepository.GetById(statusId);
            return result;
        }
    }
}
