using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public static class ActivityMapper
    {
        public static Activity Map(ActivityDto dto)
        {
            if (dto == null) return null;

            return new Activity()
                .SetTitle(dto.Title)
                .SetDescription(dto.Description)
                .SetPlaces(dto.Places)
                .SetImage(dto.Image)
                //.SetDates(activityDto.ActivityStart, activityDto.ActivityEnd)
                .SetStatus(dto.StatusId)
                .SetTimeSlot(dto.TimeSlotId)
                .SetType(dto.TypeId);
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
                Title = activity.Title,
                Description = activity.Description,
                Places = activity.Places,
                Image = activity.Image,
                TypeId = activity.Type,
                StatusId = activity.Status,
                //EndDateTime = activity.EndDateTime,
                //StartDateTime = activity.StartDateTime,
                TimeSlotId = activity.TimeSlot ?? 0
            };
        }

        public static List<ActivityDto> Map(List<Activity> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(Map).ToList();
        }

        public static ActivityDto Map(ActivityEntity activity)
        {
            if (activity == null) return null;

            return new ActivityDto
            {
                Title = activity.Title,
                Description = activity.Description,
                Places = activity.Places,
                Image = activity.Image,
                TypeId = activity.TypeId,
                StatusId = activity.StatusId,
                TimeSlotId = activity.TimeSlotId.Value
            };
        }

        internal static List<ActivityDto> Map(List<ActivityEntity> activities)
        {
            if (activities == null || activities.Count == 0) return null;

            return activities.Select(Map).ToList();
        }
    }
}
