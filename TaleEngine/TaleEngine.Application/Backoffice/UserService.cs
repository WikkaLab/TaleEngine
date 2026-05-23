using System;
using System.Collections.Generic;
using TaleEngine.Aggregates.UserAggregate;
using TaleEngine.Cross.Enums;
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

        public UserEntity Register(User user)
        {
            if (user == null
                || string.IsNullOrWhiteSpace(user.Username)
                || string.IsNullOrWhiteSpace(user.Mail))
            {
                return null;
            }

            var userEntity = new UserEntity
            {
                Username = user.Username,
                Name = user.Name,
                Mail = user.Mail,
                Website = user.Website,
                Blog = user.Blog,
                StatusId = user.Status == default ? (int)UserStatusEnum.PENDING : user.Status
            };

            _unitOfWork.UserRepository.Insert(userEntity);
            _unitOfWork.UserRepository.Save();

            return userEntity;
        }

        public void UpdateProfile(int id, User user)
        {
            if (id == default || user == null)
            {
                return;
            }

            var userEntity = _unitOfWork.UserRepository.GetById(id);

            if (userEntity == null)
            {
                return;
            }

            userEntity.Name = user.Name;
            userEntity.Mail = user.Mail;
            userEntity.Website = user.Website;
            userEntity.Blog = user.Blog;

            _unitOfWork.UserRepository.Update(userEntity);
            _unitOfWork.UserRepository.Save();
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
