using System.Collections.Generic;
using System.Linq;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public static class ActivityTypeMapper
    {
        public static ActivityTypeDto Map(ActivityTypeModel activityType)
        {
            if (activityType == null) return null;

            return new ActivityTypeDto
            {
                Id = activityType.Id,
                Name = activityType.Name
            };
        }

        public static List<ActivityTypeDto> Map(List<ActivityTypeModel> activityTypes)
        {
            if (activityTypes == null || activityTypes.Count == 0) return null;

            return activityTypes.Select(Map).ToList();
        }

        public static ActivityTypeModel Map(ActivityTypeDto activityTypeDto)
        {
            if (activityTypeDto == null) return null;

            return new ActivityTypeModel
            {
                Id = activityTypeDto.Id,
                Name = activityTypeDto.Name
            };
        }

        public static List<ActivityTypeModel> Map(List<ActivityTypeDto> activityTypeDtos)
        {
            if (activityTypeDtos == null || activityTypeDtos.Count == 0) return null;

            return activityTypeDtos.Select(Map).ToList();
        }
    }
}
