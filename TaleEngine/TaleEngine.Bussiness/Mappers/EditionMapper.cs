using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public static class EditionMapper
    {
        public static EditionDto Map(EditionEntity entity)
        {
            if (entity == null) return null;

            return new EditionDto
            {
                Id = entity.Id,
                EventId = entity.EventId
            };
        }

        public static List<EditionDto> Map(List<EditionEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
