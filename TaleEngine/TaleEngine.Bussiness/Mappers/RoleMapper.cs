using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public class RoleMapper
    {
        public static RoleDto Map(RoleEntity entity)
        {
            if (entity == null) return null;

            return new RoleDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public static List<RoleDto> Map(List<RoleEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
