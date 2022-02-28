using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public static class ActivityTypeMapper
    {
        public static ActivityTypeDto Map(ActivityTypeEntity entity)
        {
            return new ActivityTypeDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static List<ActivityTypeDto> Map(List<ActivityTypeEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
