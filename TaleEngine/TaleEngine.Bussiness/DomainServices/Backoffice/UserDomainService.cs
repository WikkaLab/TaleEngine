using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
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

        public List<UserModel> GetAllUsers()
        {
            var entities = _unitOfWork.UserRepository.GetAll();

            var result = UserMapper.MapToUserModels(entities);
            return result;
        }
    }
}
