using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
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
