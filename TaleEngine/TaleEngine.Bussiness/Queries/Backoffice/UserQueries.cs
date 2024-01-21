using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries.Backoffice
{
    public class UserQueries : IUserQueries
    {

        private readonly IUserStatusQueries _userStatusCommands;
        private readonly IUserService _service;

        public UserQueries(IUserService userService, IUserStatusQueries userStatusCommands)
        {
            _userStatusCommands = userStatusCommands ?? throw new ArgumentNullException(nameof(userStatusCommands));
            _service = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public List<UserDto> AllUsersQuery()
        {
            var entities = _service.GetAllUsers();

            var result = UserMapper.MapToUserModels(entities);
            return result;
        }

        public UserDto UserQuery(int userId)
        {
            if (userId == 0) return null;

            var entity = _service.GetById(userId);
            var model = UserMapper.Map(entity);
            return model;
        }
    }
}
