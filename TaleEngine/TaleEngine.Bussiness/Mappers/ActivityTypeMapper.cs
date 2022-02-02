using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Commands.Mappers
{
    public static class ActivityTypeMapper
    {
        public static ActivityTypeEntity Map(ActivityTypeModel activityTypeModel)
        {
            if (activityTypeModel == null) return null;

            return new ActivityTypeEntity
            {
                Id = activityTypeModel.Id,
                Name = activityTypeModel.Name
            };
        }

        public static List<ActivityTypeEntity> Map(List<ActivityTypeModel> activityTypeModels)
        {
            if (activityTypeModels == null || activityTypeModels.Count == 0) return null;

            return activityTypeModels.Select(Map).ToList();
        }

        public static ActivityTypeModel Map(ActivityTypeEntity activityType)
        {
            if (activityType == null) return null;

            return new ActivityTypeModel
            {
                Id = activityType.Id,
                Name = activityType.Name
            };
        }

        public static List<ActivityTypeModel> Map(List<ActivityTypeEntity> activityTypes)
        {
            if (activityTypes == null || activityTypes.Count == 0) return null;

            return activityTypes.Select(Map).ToList();
        }
    }
}
