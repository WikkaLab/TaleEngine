using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.DomainServices
{
    public class RoleDomainService : IRoleDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<RoleModel> GetAllRoles()
        {
            List<Role> roles = _unitOfWork.RoleRepository.GetAll().ToList();

            List<RoleModel> roleModels = RoleMapper.MapToRoleModels(roles);
            return roleModels;
        }
    }
}
