using System;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public static class ActivityMapper
    {
        public static ActivityDto Map(ActivityModel activityModel)
        {
            if (activityModel == null) return null;

            return new ActivityDto
            {
                Id = activityModel.Id,
                Title = activityModel.Title,
                Description = activityModel.Description,
                Places = activityModel.Places,
                ActivityEnd = activityModel.EndDateTime.ToString(),
                ActivityStart = activityModel.StartDateTime.ToString(),
                StatusId = activityModel.StatusId,
                TypeId = activityModel.TypeId,
                Image = activityModel.Image,
                TimeSlotId = activityModel.TimeSlotId ?? 0
            };
        }

        public static ActivityModel Map(ActivityDto activityDto)
        {
            if (activityDto == null) return null;

            return new ActivityModel
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
