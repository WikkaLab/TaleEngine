using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class ActivityStatusMapper
    {
        public static ActivityStatusDto Map(ActivityStatus activityStatus)
        {
            return new ActivityStatusDto
            {
                Id = activityStatus.Id,
                Name = activityStatus.Name
            };
        }

        public static ActivityStatus Map(ActivityStatusDto activityStatusDto)
        {
            return new ActivityStatus
            {
                Id = activityStatusDto.Id,
                Name = activityStatusDto.Name
            };
        }
    }
}
