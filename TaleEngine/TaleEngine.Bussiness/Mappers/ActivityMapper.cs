using System.Collections.Generic;
using System.Linq;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public static class ActivityMapper
    {
        public static Activity MapDtoToModel(ActivityDto dto)
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

        public static List<Activity> MapDtoToModel(List<ActivityDto> dtos)
        {
            if (dtos == null || dtos.Count == 0) return null;

            return dtos.Select(MapDtoToModel).ToList();
        }

        public static ActivityDto MapModelToDto(Activity activity)
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

        public static List<ActivityDto> MapModelToDto(List<Activity> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(MapModelToDto).ToList();
        }

        // entity to dto
        public static ActivityDto MapEntityToDto(ActivityEntity activity)
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

        public static List<ActivityDto> MapEntityToDto(List<ActivityEntity> activities)
        {
            if (activities == null || activities.Count == 0) return null;

            return activities.Select(MapEntityToDto).ToList();
        }

        public static Activity MapEntityToModel(ActivityEntity entitiy)
        {
            if (entitiy == null) return null;

            return new Activity()
                .SetTitle(entitiy.Title)
                .SetDescription(entitiy.Description)
                .SetPlaces(entitiy.Places)
                .SetImage(entitiy.Image)
                //.SetDates(activityDto.ActivityStart, activityDto.ActivityEnd)
                .SetStatus(entitiy.StatusId)
                .SetTimeSlot(entitiy.TimeSlotId.Value)
                .SetType(entitiy.TypeId);
        }
    }
}
