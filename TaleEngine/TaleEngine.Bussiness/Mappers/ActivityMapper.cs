using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class ActivityMapper
    {
        public static ActivityDto Map(Activity activity)
        {
            return new ActivityDto
            {
                Title = activity.Title,
                Description = activity.Description,
                Places = activity.Places
            };
        }

        public static Activity Map(ActivityDto activityDto)
        {
            return new Activity
            {
                Title = activityDto.Title,
                Description = activityDto.Description,
                Places = activityDto.Places
            };
        }
    }
}
