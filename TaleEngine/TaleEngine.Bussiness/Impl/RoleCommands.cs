using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.CQRS.Impl
{
    public class RoleCommands : IRoleCommands
    {
        private readonly RoleService _roleService;

        public RoleCommands(RoleService roleService)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

        public List<RoleDto> GetAllRoles()
        {
            List<RoleModels> roles = _roleService.GetAll();

            if (roles == null || roles.Count == 0)
            {
                return null;
            }



            List<RoleDto> roleDtos = RoleMapper.MapToRoleDtos(roles);
            return roleDtos;
        }
    }
}
