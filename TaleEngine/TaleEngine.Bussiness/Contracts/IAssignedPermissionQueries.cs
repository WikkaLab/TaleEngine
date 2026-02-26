using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IAssignedPermissionQueries
    {
        List<AssignedPermissionDto> GetPermissionsByRoleQuery(int roleId);
        List<AssignedPermissionDto> AllAssignedPermissionsQuery();
    }
}
