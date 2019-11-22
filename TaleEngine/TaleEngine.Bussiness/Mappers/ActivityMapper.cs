using System;
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
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                Places = activity.Places,
                ActivityEnd = activity.EndDateTime.ToString(),
                ActivityStart = activity.StartDateTime.ToString(),
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
                Id = activityDto.Id,
                Title = activityDto.Title,
                Description = activityDto.Description,
                Places = activityDto.Places,
                Image = activityDto.Image,
                TypeId = activityDto.TypeId,
                StatusId = activityDto.StatusId,
                EndDateTime = ParseTime(activityDto.ActivityEnd),
                StartDateTime = ParseTime(activityDto.ActivityStart),
                TimeSlotId = activityDto.TimeSlotId
            };
        }

        private static DateTime? ParseTime(string date)
        {
            DateTime? result;

            try
            {
                result = DateTime.Parse(date);
            }
            catch (Exception e)
            {
                result = null;
            }

            return result;
        }
    }
}
