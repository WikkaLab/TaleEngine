using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;

namespace TaleEngine.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public RoleEntity GetRole(int id)
        {
            var role = _unitOfWork.RoleRepository.GetById(id);
            return role;
        }

        public List<RoleEntity> GetAllRoles()
        {
            var roles = _unitOfWork.RoleRepository.GetAll();
            return roles;
        }
    }
}
