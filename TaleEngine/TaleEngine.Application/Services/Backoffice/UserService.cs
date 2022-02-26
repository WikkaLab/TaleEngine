using System;
using System.Collections.Generic;
using TaleEngine.Aggregates.UserAggregate;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services.Backoffice
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException();
        }

        public void ChangeUserStatus(int id, User user)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> GetAllUsers()
        {
            var result = _unitOfWork.UserRepository.GetAll();
            return result;
        }

        public UserEntity GetById(int id)
        {
            var result = _unitOfWork.UserRepository.GetById(id);
            return result;
        }
    }
}
