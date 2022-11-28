using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IRoleQueries
    {
        List<RoleDto> AllRolesQuery();
    }
}
