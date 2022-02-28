using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<RoleEntity> GetAllRoles()
        {
            var roles = _unitOfWork.RoleRepository.GetAll();
            return roles;
        }
    }
}
