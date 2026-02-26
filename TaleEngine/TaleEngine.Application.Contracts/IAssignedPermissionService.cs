using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface IAssignedPermissionService
    {
        AssignedPermissionEntity GetAssignedPermission(int id);
        List<AssignedPermissionEntity> GetAllAssignedPermissions();
        List<AssignedPermissionEntity> GetAssignedPermissionsByRole(int roleId);
        void AssignPermissionToRole(int roleId, int permissionId, int permissionValueId);
        void RemovePermissionFromRole(int roleId, int permissionId, int permissionValueId);
    }
}
