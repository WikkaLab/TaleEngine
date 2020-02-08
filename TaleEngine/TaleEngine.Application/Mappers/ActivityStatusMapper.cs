using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public static class ActivityStatusMapper
    {
        public static ActivityStatusDto Map(ActivityStatusModel activityStatus)
        {
            return new ActivityStatusDto
            {
                Id = activityStatus.Id,
                Name = activityStatus.Name
            };
        }

        public static ActivityStatusModel Map(ActivityStatusDto activityStatusDto)
        {
            return new ActivityStatusModel
            {
                Id = activityStatusDto.Id,
                Name = activityStatusDto.Name
            };
        }
    }
}
