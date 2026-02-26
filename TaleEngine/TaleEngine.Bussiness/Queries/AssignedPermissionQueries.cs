using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class AssignedPermissionQueries : IAssignedPermissionQueries
    {
        private readonly IAssignedPermissionService _service;

        public AssignedPermissionQueries(IAssignedPermissionService assignedPermissionService)
        {
            _service = assignedPermissionService ?? throw new ArgumentNullException(nameof(assignedPermissionService));
        }

        public List<AssignedPermissionDto> GetPermissionsByRoleQuery(int roleId)
        {
            var assignedPermissions = _service.GetAssignedPermissionsByRole(roleId);

            if (assignedPermissions == null || assignedPermissions.Count == 0)
            {
                return null;
            }

            var dtos = AssignedPermissionMapper.Map(assignedPermissions);
            return dtos;
        }

        public List<AssignedPermissionDto> AllAssignedPermissionsQuery()
        {
            var assignedPermissions = _service.GetAllAssignedPermissions();

            if (assignedPermissions == null || assignedPermissions.Count == 0)
            {
                return null;
            }

            var dtos = AssignedPermissionMapper.Map(assignedPermissions);
            return dtos;
        }
    }
}
