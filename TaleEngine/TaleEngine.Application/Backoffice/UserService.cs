using System;
using System.Collections.Generic;
using TaleEngine.Aggregates.UserAggregate;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;

namespace TaleEngine.Services.Backoffice
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException();
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

        public void ChangeUserStatus(int id, User user)
        {
            var userEntity = _unitOfWork.UserRepository.GetById(id);
            if (userEntity == null) return;

            userEntity.StatusId = user.Status;
            _unitOfWork.UserRepository.Update(userEntity);
            _unitOfWork.UserRepository.Save();
        }

        public void AssignRoleToUser(int id, int roleId)
        {
            var userEntity = _unitOfWork.UserRepository.GetById(id);
            if (userEntity == null) return;

            var role = _unitOfWork.RoleRepository.GetById(roleId);
            if (role == null) return;

            userEntity.Roles.Add(role);
            _unitOfWork.UserRepository.Update(userEntity);
            _unitOfWork.UserRepository.Save();
        }
    }
}
