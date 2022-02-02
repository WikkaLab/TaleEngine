using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Domain.Models;

namespace TaleEngine.DbServices.Mappers
{
    public class ActivityMapper
    {
        public static Activity Map(ActivityEntity entity)
        {
            if (entity == null) return null;

            var activity = new Activity
            {
                Id = entity.Id,
                Image = entity.Image,
                Places = entity.Places,
                Title = entity.Title,
                StatusId = entity.StatusId,
                TypeId = entity.TypeId,
                Description = entity.Description,
                TimeSlotId = entity.TimeSlotId,
            };

            return activity;
        }

        public static List<Activity> Map(List<ActivityEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
