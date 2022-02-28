using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public static class ActivityStatusMapper
    {
        public static ActivityStatusDto Map(ActivityStatusEntity entity)
        {
            return new ActivityStatusDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static List<ActivityStatusDto> Map(List<ActivityStatusEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
