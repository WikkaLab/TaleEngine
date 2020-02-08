using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class ActivityTypeMapper
    {
        public static ActivityType Map(ActivityTypeModel activityTypeModel)
        {
            return new ActivityType
            {
                Id = activityTypeModel.Id,
                Name = activityTypeModel.Name
            };
        }

        public static ActivityTypeModel Map(ActivityType activityType)
        {
            return new ActivityTypeModel
            {
                Id = activityType.Id,
                Name = activityType.Name
            };
        }
    }
}
