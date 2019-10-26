using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class ActivityMapper
    {
        public static ActivityDto Map(Activity activity)
        {
            return new ActivityDto
            {
                Title = activity.Title,
                Description = activity.Description,
                Places = activity.Places,
                ActivityEnd = activity.EndDateTime,
                ActivityStart = activity.StartDateTime,
                StatusId = activity.StatusId,
                TypeId = activity.TypeId,
                Image = activity.Image,
                TimeSlotId = activity.TimeSlotId ?? 0
            };
        }

        public static Activity Map(ActivityDto activityDto)
        {
            return new Activity
            {
                Title = activityDto.Title,
                Description = activityDto.Description,
                Places = activityDto.Places,
                Image = activityDto.Image,
                TypeId = activityDto.TypeId,
                StatusId = activityDto.StatusId,
                EndDateTime = activityDto.ActivityEnd.ToUniversalTime(),
                StartDateTime = activityDto.ActivityStart.ToUniversalTime(),
                TimeSlotId = activityDto.TimeSlotId
            };
        }
    }
}
