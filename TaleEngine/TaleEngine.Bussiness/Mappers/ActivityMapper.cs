using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class ActivityMapper
    {
        public static Activity Map(ActivityModel activityModel)
        {
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

        public static ActivityModel Map(Activity activity)
        {
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
        
    }
}
