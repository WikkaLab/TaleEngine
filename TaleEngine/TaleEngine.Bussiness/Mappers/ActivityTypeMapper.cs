using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class ActivityTypeMapper
    {
        public static ActivityTypeDto Map(ActivityType activityType)
        {
            return new ActivityTypeDto
            {
                Id = activityType.Id,
                Name = activityType.Name
            };
        }

        public static ActivityType Map(ActivityTypeDto activityTypeDto)
        {
            return new ActivityType
            {
                Id = activityTypeDto.Id,
                Name = activityTypeDto.Name
            };
        }
    }
}
