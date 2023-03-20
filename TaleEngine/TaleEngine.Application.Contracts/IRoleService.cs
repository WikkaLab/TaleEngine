using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface IRoleService
    {
        RoleEntity GetRole(int id);
        List<RoleEntity> GetAllRoles();
    }
}
