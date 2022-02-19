using System;
using System.Collections.Generic;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.CQRS.Impl.Backoffice
{
    public class UserCommands : IUserCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserStatusCommands _userStatusDomainService;

        public UserCommands(IUnitOfWork unitOfWork,
            IUserStatusCommands userStatusDomainService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userStatusDomainService = userStatusDomainService ?? throw new ArgumentNullException(nameof(userStatusDomainService));
        }

        public List<UserDto> GetAllUsers()
        {
            var entities = _unitOfWork.UserRepository.GetAll();

            var result = UserMapper.MapToUserModels(entities);
            return result;
        }

        public int ActivateUser(int userId)
        {
            if (userId == 0) return 0;
            var status = _userStatusDomainService.GetActiveStatus();
            if (status == 0) return 0;
            int result = ChangeUserStatusTo(userId, status);

            return result;
        }

        public int BanUser(int userId)
        {
            if (userId == 0) return 0;
            var status = _userStatusDomainService.GetActiveStatus();
            if (status == 0) return 0;
            int result = ChangeUserStatusTo(userId, status);

            return result;
        }

        public int DeactivateUser(int userId)
        {
            if (userId == 0) return 0;
            var status = _userStatusDomainService.GetInactiveStatus();
            if (status == 0) return 0;
            int result = ChangeUserStatusTo(userId, status);

            return result;
        }

        public int MarkAsPendingUser(int userId)
        {
            if (userId == 0) return 0;
            var status = _userStatusDomainService.GetPendingStatus();
            if (status == 0) return 0;
            int result = ChangeUserStatusTo(userId, status);

            return result;
        }

        public int ReviewUser(int userId)
        {
            if (userId == 0) return 0;
            var status = _userStatusDomainService.GetRevisionStatus();
            if (status == 0) return 0;
            int result = ChangeUserStatusTo(userId, status);

            return result;
        }

        public UserModel GetUser(int userId)
        {
            if (userId == 0) return null;

            var entity = _unitOfWork.UserRepository.GetById(userId);
            var model = UserMapper.Map(entity);
            return model;
        }

        private int ChangeUserStatusTo(int userId, int status)
        {
            var user = _unitOfWork.UserRepository.GetById(userId);
            if (user == null) return 0;

            try
            {
                user.StatusId = status;
                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.UserRepository.Save();

                return user.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
