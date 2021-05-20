using System.Collections.Generic;
using System.Linq;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class ActivityTypeMapper
    {
        public static ActivityType Map(ActivityTypeModel activityTypeModel)
        {
            if (activityTypeModel == null) return null;

            return new ActivityType
            {
                Id = activityTypeModel.Id,
                Name = activityTypeModel.Name
            };
        }

        public static List<ActivityType> Map(List<ActivityTypeModel> activityTypeModels)
        {
            if (activityTypeModels == null || activityTypeModels.Count == 0) return null;

            return activityTypeModels.Select(Map).ToList();
        }

        public static ActivityTypeModel Map(ActivityType activityType)
        {
            if (activityType == null) return null;

            return new ActivityTypeModel
            {
                Id = activityType.Id,
                Name = activityType.Name
            };
        }

        public static List<ActivityTypeModel> Map(List<ActivityType> activityTypes)
        {
            if (activityTypes == null || activityTypes.Count == 0) return null;

            return activityTypes.Select(Map).ToList();
        }
    }
}
