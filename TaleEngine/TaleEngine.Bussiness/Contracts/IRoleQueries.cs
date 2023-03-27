using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IRoleQueries
    {
        RoleDto GetRoleQuery(int roleId);
        List<RoleDto> AllRolesQuery();
    }
}
