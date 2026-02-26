using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface IPermissionValueService
    {
        PermissionValueEntity GetPermissionValue(int id);
        List<PermissionValueEntity> GetAllPermissionValues();
        void CreatePermissionValue(PermissionValueEntity permissionValue);
        void UpdatePermissionValue(PermissionValueEntity permissionValue);
        void DeletePermissionValue(int id);
    }
}
