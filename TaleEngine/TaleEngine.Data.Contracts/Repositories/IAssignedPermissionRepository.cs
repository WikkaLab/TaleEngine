using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface IAssignedPermissionRepository : IGenericRepository<AssignedPermissionEntity>
    {
        List<AssignedPermissionEntity> GetByRoleId(int roleId);
        void DeleteByRoleIdAndPermissionId(int roleId, int permissionId, int permissionValueId);
    }
}
