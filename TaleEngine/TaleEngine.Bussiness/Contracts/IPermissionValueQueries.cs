using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IPermissionValueQueries
    {
        PermissionValueDto GetPermissionValueQuery(int permissionValueId);
        List<PermissionValueDto> AllPermissionValuesQuery();
    }
}
