using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Commands.Mappers
{
    public static class ActivityStatusMapper
    {
        public static ActivityStatusEntity Map(ActivityStatusModel activityStatusModel)
        {
            return new ActivityStatusEntity
            {
                Id = activityStatusModel.Id,
                Name = activityStatusModel.Name
            };
        }

        public static List<ActivityStatusEntity> Map(List<ActivityStatusModel> activityStatusModels)
        {
            if (activityStatusModels == null || activityStatusModels.Count == 0) return null;

            return activityStatusModels.Select(Map).ToList();
        }

        public static ActivityStatusModel Map(ActivityStatusEntity activityStatus)
        {
            return new ActivityStatusModel
            {
                Id = activityStatus.Id,
                Name = activityStatus.Name
            };
        }

        public static List<ActivityStatusModel> Map(List<ActivityStatusEntity> activityStatus)
        {
            if (activityStatus == null || activityStatus.Count == 0) return null;

            return activityStatus.Select(Map).ToList();
        }
    }
}
