using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Domain.Models;

namespace TaleEngine.Commands.Mappers
{
    public static class ActivityMapper
    {
        // To models from DTO

        public static Activity Map(ActivityDto dto)
        {
            if (dto == null) return null;

            return new Activity
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Places = dto.Places,
                //EndDateTime = dto.ActivityEnd,
                //StartDateTime = dto.ActivityStart,
                StatusId = dto.StatusId,
                TypeId = dto.TypeId,
                Image = dto.Image,
                TimeSlotId = dto.TimeSlotId
            };
        }

        public static List<Activity> Map(List<ActivityDto> dtos)
        {
            if (dtos == null || dtos.Count == 0) return null;

            return dtos.Select(Map).ToList();
        }

        public static ActivityDto Map(Activity activity)
        {
            if (activity == null) return null;

            return new ActivityDto
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                Places = activity.Places,
                Image = activity.Image,
                TypeId = activity.TypeId,
                StatusId = activity.StatusId,
                //EndDateTime = activity.EndDateTime,
                //StartDateTime = activity.StartDateTime,
                TimeSlotId = activity.TimeSlotId ?? 0
            };
        }

        public static List<ActivityDto> Map(List<Activity> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(Map).ToList();
        }

    }
}
