using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.CQRS.Impl
{
    public class RoleCommands : IRoleCommands
    {
        private readonly IRoleService _service;

        public RoleCommands(IRoleService roleService)
        {
            _service = roleService ?? throw new ArgumentNullException(nameof(roleService));
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
