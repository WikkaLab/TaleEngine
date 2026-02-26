using System;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.CQRS.Contracts;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Commands
{
    public class AssignedPermissionCommands : IAssignedPermissionCommands
    {
        private readonly IAssignedPermissionService _service;

        public AssignedPermissionCommands(IAssignedPermissionService assignedPermissionService)
        {
            _service = assignedPermissionService ?? throw new ArgumentNullException(nameof(assignedPermissionService));
        }

        public void AssignPermissionCommand(AssignPermissionRequest request)
        {
            _service.AssignPermissionToRole(request.RoleId, request.PermissionId, request.PermissionValueId);
        }

        public void RemovePermissionCommand(AssignPermissionRequest request)
        {
            _service.RemovePermissionFromRole(request.RoleId, request.PermissionId, request.PermissionValueId);
        }
    }
}
