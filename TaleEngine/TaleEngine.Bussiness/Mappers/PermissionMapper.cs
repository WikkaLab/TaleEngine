using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public class PermissionMapper
    {
        public static PermissionDto Map(PermissionEntity entity)
        {
            if (entity == null) return null;

            return new PermissionDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Abbr = entity.Abbr,
                Description = entity.Description
            };
        }

        public static List<PermissionDto> Map(List<PermissionEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }

        public static PermissionEntity MapToEntity(PermissionDto dto)
        {
            if (dto == null) return null;

            return new PermissionEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Abbr = dto.Abbr,
                Description = dto.Description
            };
        }
    }
}
