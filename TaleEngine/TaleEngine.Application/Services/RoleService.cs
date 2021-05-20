using System;
using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Mappers;
using TaleEngine.Bussiness.Contracts.DomainServices;

namespace TaleEngine.Application.Services
{
    public class RoleService : IRoleService
    {
        private IRoleDomainService _roleDomainService;

        public RoleService(IRoleDomainService roleDomainService)
        {
            _roleDomainService = roleDomainService ?? throw new ArgumentNullException(nameof(roleDomainService));
        }

        public List<RoleDto> GetAllRoles()
        {
            var roleModels = _roleDomainService.GetAllRoles();

            var dtos = RoleMapper.MapToRoleDtos(roleModels);

            return dtos;
        }
    }
}
