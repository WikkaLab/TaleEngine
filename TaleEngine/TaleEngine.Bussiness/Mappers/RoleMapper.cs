using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Commands.Mappers
{
    public class RoleMapper
    {
        public static RoleEntity Map(RoleModel roleModel)
        {
            if (roleModel == null) return null;

            return new RoleEntity
            {
                Id = roleModel.Id,
                Name = roleModel.Name,
                Description = roleModel.Description
            };
        }

        public static RoleModel Map(RoleEntity roleEntity)
        {
            if (roleEntity == null) return null;

            return new RoleModel
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
                Description = roleEntity.Description
            };
        }

        public static List<RoleEntity> MapToRoles(List<RoleModel> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(Map).ToList();
        }

        public static List<RoleModel> MapToRoleModels(List<RoleEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
