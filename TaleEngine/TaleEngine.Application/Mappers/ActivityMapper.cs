using System.Collections.Generic;
using System.Linq;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.DbServices.Mappers
{
    public class ActivityMapper
    {
        public static Activity Map(ActivityEntity entity)
        {
            if (entity == null) return null;

            var activity = new Activity()
                .SetTitle(entity.Title)
                .SetDescription(entity.Description)
                .SetPlaces(entity.Places)
                .SetImage(entity.Image)
                .SetStatus(entity.StatusId)
                .SetType(entity.TypeId)
                .SetTimeSlot(entity.TimeSlotId.Value);

            return activity;
        }

        public static List<Activity> Map(List<ActivityEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
