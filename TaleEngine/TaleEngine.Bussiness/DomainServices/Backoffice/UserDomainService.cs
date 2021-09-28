using System;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Data.Contracts;

namespace TaleEngine.Bussiness.DomainServices.Backoffice
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException();
        }

    }
}
