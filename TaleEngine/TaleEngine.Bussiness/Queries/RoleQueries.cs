using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class RoleQueries : IRoleQueries
    {
        private readonly IRoleService _service;

        public RoleQueries(IRoleService roleService)
        {
            _service = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

        public RoleDto GetRoleQuery(int roleId)
        {
            var role = _service.GetRole(roleId);

            var dto = RoleMapper.Map(role);
            return dto;
        }

        public List<RoleDto> AllRolesQuery()
        {
            var roles = _service.GetAllRoles();

            if (roles == null || roles.Count == 0)
            {
                return null;
            }

            var dtos = RoleMapper.Map(roles);
            return dtos;
        }
    }
}
