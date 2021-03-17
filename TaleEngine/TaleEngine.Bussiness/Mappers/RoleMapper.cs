using System.Collections.Generic;
using System.Linq;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public class RoleMapper
    {
        public static Role Map(RoleModel roleModel)
        {
            if (roleModel == null) return null;

            return new Role
            {
                Id = roleModel.Id,
                Name = roleModel.Name,
                Description = roleModel.Description
            };
        }

        public static RoleModel Map(Role roleEntity)
        {
            if (roleEntity == null) return null;

            return new RoleModel
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
                Description = roleEntity.Description
            };
        }

        public static List<Role> MapToRoles(List<RoleModel> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(Map).ToList();
        }

        public static List<RoleModel> MapToRoleModels(List<Role> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
