using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IPermissionQueries
    {
        PermissionDto GetPermissionQuery(int permissionId);
        List<PermissionDto> AllPermissionsQuery();
    }
}
