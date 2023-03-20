using System;
using TaleEngine.CQRS.Contracts;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Commands.Backoffice
{
    public class UserCommands : IUserCommands
    {
        private readonly IUserStatusQueries _userStatusCommands;
        private readonly IUserService _service;

        public UserCommands(IUserStatusQueries userStatusCommands)
        {
            _userStatusCommands = userStatusCommands ?? throw new ArgumentNullException(nameof(userStatusCommands));
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

        private void ChangeUserStatusTo(int userId, int status)
        {
            var user = _service.GetById(userId);
            if (user == null) return;

            throw new NotImplementedException();
        }
    }
}
