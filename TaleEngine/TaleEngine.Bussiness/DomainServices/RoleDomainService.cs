using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Bussiness.DomainServices
{
    public class RoleDomainService : IRoleDomainService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleDomainService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public List<RoleModel> GetAllRoles()
        {
            List<Role> roles = _roleRepository.GetAll();

            if (roles == null || roles.Count == 0)
            {
                return null;
            }

            List<RoleModel> roleModels = RoleMapper.MapToRoleModels(roles);
            return roleModels;
        }
    }
}