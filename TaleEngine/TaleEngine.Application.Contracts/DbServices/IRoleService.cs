using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IRoleService
    {
        List<RoleEntity> GetAllRoles();
    }
}
