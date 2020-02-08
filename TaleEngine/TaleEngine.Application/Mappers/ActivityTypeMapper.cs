using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public static class ActivityTypeMapper
    {
        public static ActivityTypeDto Map(ActivityTypeModel activityType)
        {
            return new ActivityTypeDto
            {
                Id = activityType.Id,
                Name = activityType.Name
            };
        }

        public static ActivityTypeModel Map(ActivityTypeDto activityTypeDto)
        {
            return new ActivityTypeModel
            {
                Id = activityTypeDto.Id,
                Name = activityTypeDto.Name
            };
        }
    }
}
