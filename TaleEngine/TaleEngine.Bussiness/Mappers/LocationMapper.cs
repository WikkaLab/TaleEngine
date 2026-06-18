using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public class LocationMapper
    {
        public static LocationDto Map(LocationEntity entity)
        {
            if (entity == null) return null;

            return new LocationDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Capacity = entity.Capacity,
                EditionId = entity.EditionId
            };
        }

        public static List<LocationDto> Map(List<LocationEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }

        public static LocationEntity MapToEntity(LocationDto dto)
        {
            if (dto == null) return null;

            return new LocationEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Capacity = dto.Capacity,
                EditionId = dto.EditionId
            };
        }
    }
}
