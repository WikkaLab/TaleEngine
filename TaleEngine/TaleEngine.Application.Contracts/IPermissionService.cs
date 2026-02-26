using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface IPermissionService
    {
        PermissionEntity GetPermission(int id);
        List<PermissionEntity> GetAllPermissions();
        void CreatePermission(PermissionEntity permission);
        void UpdatePermission(PermissionEntity permission);
        void DeletePermission(int id);
    }
}
