using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public class PermissionValueMapper
    {
        public static PermissionValueDto Map(PermissionValueEntity entity)
        {
            if (entity == null) return null;

            return new PermissionValueDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Abbr = entity.Abbr,
                Description = entity.Description
            };
        }

        public static List<PermissionValueDto> Map(List<PermissionValueEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }

        public static PermissionValueEntity MapToEntity(PermissionValueDto dto)
        {
            if (dto == null) return null;

            return new PermissionValueEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Abbr = dto.Abbr,
                Description = dto.Description
            };
        }
    }
}
