using System;
using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Mappers;
using TaleEngine.Bussiness.Contracts.DomainServices;

namespace TaleEngine.Application.Services.Backoffice
{
    public class UserService : IUserService
    {
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
    }
}
