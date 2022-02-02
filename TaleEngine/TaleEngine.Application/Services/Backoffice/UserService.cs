using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services.Backoffice
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private IUserDomainService _userDomainService;

        public UserService(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService ?? throw new ArgumentNullException();
        }

        public List<UserDto> GetAllUsers()
        {
            var models = _userDomainService.GetAllUsers();

            var result = UserMapper.MapToUserDtos(models);
            return result;
        }

        public int ActivateUser(int userId)
        {
            if (userId == 0) return 0;

            int result = _userDomainService.ActivateUser(userId);
            return result;
        }

        public int BanUser(int userId)
        {
            if (userId == 0) return 0;

            int result = _userDomainService.BanUser(userId);
            return result;
        }

        public int DeactivateUser(int userId)
        {
            if (userId == 0) return 0;

            int result = _userDomainService.DeactivateUser(userId);
            return result;
        }

        public int MarkAsPendingUser(int userId)
        {
            if (userId == 0) return 0;

            int result = _userDomainService.MarkAsPendingUser(userId);
            return result;
        }

        public int ReviewUser(int userId)
        {
            if (userId == 0) return 0;

            int result = _userDomainService.ReviewUser(userId);
            return result;
        }
    }
}
