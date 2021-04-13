using System.Collections.Generic;
using System.Linq;
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

        public static List<ActivityStatus> Map(List<ActivityStatusModel> activityStatusModels)
        {
            if (activityStatusModels == null || activityStatusModels.Count == 0) return null;

            return activityStatusModels.Select(Map).ToList();
        }

        public static ActivityStatusModel Map(ActivityStatus activityStatus)
        {
            return new ActivityStatusModel
            {
                Id = activityStatus.Id,
                Name = activityStatus.Name
            };
        }

        public static List<ActivityStatusModel> Map(List<ActivityStatus> activityStatus)
        {
            if (activityStatus == null || activityStatus.Count == 0) return null;

            return activityStatus.Select(Map).ToList();
        }
    }
}
