using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class ActivityStatusMapper
    {
        public static ActivityStatus Map(ActivityStatusModel activityStatusModel)
        {
            return new ActivityStatus
            {
                Id = activityStatusModel.Id,
                Name = activityStatusModel.Name
            };
        }

        public static ActivityStatusModel Map(ActivityStatus activityStatus)
        {
            return new ActivityStatusModel
            {
                Id = activityStatus.Id,
                Name = activityStatus.Name
            };
        }
    }
}
