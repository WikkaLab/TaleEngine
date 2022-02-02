using System.Collections.Generic;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IRoleService
    {
        List<RoleDto> GetAllRoles();
    }
}
