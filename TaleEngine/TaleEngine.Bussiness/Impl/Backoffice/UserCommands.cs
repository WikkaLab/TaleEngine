using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.CQRS.Impl.Backoffice
{
    public class UserCommands : IUserCommands
    {
        private readonly IUserStatusCommands _userStatusCommands;
        private readonly IUserService _service;

        public UserCommands(IUserStatusCommands userStatusCommands)
        {
            _userStatusCommands = userStatusCommands ?? throw new ArgumentNullException(nameof(userStatusCommands));
        }

        public List<UserDto> AllUsersQuery()
        {
            var entities = _service.GetAllUsers();

            var result = UserMapper.MapToUserModels(entities);
            return result;
        }

        public void ActivateCommand(int userId)
        {
            if (userId == 0) return;
            var status = _userStatusCommands.ActiveQuery();
            if (status == 0) return;
            //ChangeUserStatusTo(userId, status);
        }

        public void BanCommand(int userId)
        {
            if (userId == 0) return;
            var status = _userStatusCommands.BanQuery();
            if (status == 0) return;
            //ChangeUserStatusTo(userId, status);
        }

        public void DeactivateCommand(int userId)
        {
            if (userId == 0) return;
            var status = _userStatusCommands.InactiveQuery();
            if (status == 0) return;
            //ChangeUserStatusTo(userId, status);
        }

        public void MarkAsPendingCommand(int userId)
        {
            if (userId == 0) return;
            var status = _userStatusCommands.PendingQuery();
            if (status == 0) return;
            //ChangeUserStatusTo(userId, status);
        }

        public void ReviewCommand(int userId)
        {
            if (userId == 0) return;
            var status = _userStatusCommands.RevisionQuery();
            if (status == 0) return;
            //ChangeUserStatusTo(userId, status);
        }

        public UserDto UserQuery(int userId)
        {
            if (userId == 0) return null;

            var entity = _service.GetById(userId);
            var model = UserMapper.Map(entity);
            return model;
        }

        private void ChangeUserStatusTo(int userId, int status)
        {
            var user = _service.GetById(userId);
            if (user == null) return;

            throw new NotImplementedException();
        }
    }
}
