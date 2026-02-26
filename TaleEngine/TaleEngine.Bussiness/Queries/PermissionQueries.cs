using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class PermissionQueries : IPermissionQueries
    {
        private readonly IPermissionService _service;

        public PermissionQueries(IPermissionService permissionService)
        {
            _service = permissionService ?? throw new ArgumentNullException(nameof(permissionService));
        }

        public PermissionDto GetPermissionQuery(int permissionId)
        {
            var permission = _service.GetPermission(permissionId);

            var dto = PermissionMapper.Map(permission);
            return dto;
        }

        public List<PermissionDto> AllPermissionsQuery()
        {
            var permissions = _service.GetAllPermissions();

            if (permissions == null || permissions.Count == 0)
            {
                return null;
            }

            var dtos = PermissionMapper.Map(permissions);
            return dtos;
        }
    }
}
