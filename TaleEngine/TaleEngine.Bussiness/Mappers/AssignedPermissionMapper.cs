using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public class AssignedPermissionMapper
    {
        public static AssignedPermissionDto Map(AssignedPermissionEntity entity)
        {
            if (entity == null) return null;

            return new AssignedPermissionDto
            {
                Id = entity.Id,
                RoleId = entity.RoleId,
                PermissionId = entity.PermissionId,
                PermissionValueId = entity.PermissionValueId,
                Permission = PermissionMapper.Map(entity.Permission),
                PermissionValue = PermissionValueMapper.Map(entity.PermissionValue)
            };
        }

        public static List<AssignedPermissionDto> Map(List<AssignedPermissionEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
