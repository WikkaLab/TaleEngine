using System.Collections.Generic;
using System.Linq;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class ActivityMapper
    {
        public static Activity Map(ActivityModel activityModel)
        {
            if (activityModel == null) return null;

            return new Activity
            {
                Id = activityModel.Id,
                Title = activityModel.Title,
                Description = activityModel.Description,
                Places = activityModel.Places,
                EndDateTime = activityModel.EndDateTime,
                StartDateTime = activityModel.StartDateTime,
                StatusId = activityModel.StatusId,
                TypeId = activityModel.TypeId,
                Image = activityModel.Image,
                TimeSlotId = activityModel.TimeSlotId ?? 0
            };
        }

        public static List<Activity> Map(List<ActivityModel> activityModels)
        {
            if (activityModels == null || activityModels.Count == 0) return null;

            return activityModels.Select(Map).ToList();
        }

        public static ActivityModel Map(Activity activity)
        {
            if (activity == null) return null;

            return new ActivityModel
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                Places = activity.Places,
                Image = activity.Image,
                TypeId = activity.TypeId,
                StatusId = activity.StatusId,
                EndDateTime = activity.EndDateTime,
                StartDateTime = activity.StartDateTime,
                TimeSlotId = activity.TimeSlotId
            };
        }

        public static List<ActivityModel> Map(List<Activity> activities)
        {
            if (activities == null || activities.Count == 0) return null;

            return activities.Select(Map).ToList();
        }

    }
}
