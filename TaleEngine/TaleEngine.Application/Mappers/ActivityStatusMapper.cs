using System.Collections.Generic;
using System.Linq;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public static class ActivityStatusMapper
    {
        public static ActivityStatusDto Map(ActivityStatusModel activityStatus)
        {
            if (activityStatus == null) return null;

            return new ActivityStatusDto
            {
                Id = activityStatus.Id,
                Name = activityStatus.Name
            };
        }

        public static List<ActivityStatusDto> Map(List<ActivityStatusModel> activityStatus)
        {
            if (activityStatus == null || activityStatus.Count == 0) return null;

            return activityStatus.Select(Map).ToList();
        }

        public static ActivityStatusModel Map(ActivityStatusDto activityStatusDto)
        {
            if (activityStatusDto == null) return null;

            return new ActivityStatusModel
            {
                Id = activityStatusDto.Id,
                Name = activityStatusDto.Name
            };
        }

        public static List<ActivityStatusModel> Map(List<ActivityStatusDto> activityStatusDtos)
        {
            if (activityStatusDtos == null || activityStatusDtos.Count == 0) return null;

            return activityStatusDtos.Select(Map).ToList();
        }
    }
}
