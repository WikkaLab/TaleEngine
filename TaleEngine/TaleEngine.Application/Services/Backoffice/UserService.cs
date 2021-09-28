using System;
using TaleEngine.Application.Contracts.Services;
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
    }
}
