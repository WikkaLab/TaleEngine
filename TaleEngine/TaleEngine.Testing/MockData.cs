using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Testing
{
    public static class MockData
    {
        public static ActivityDto GetActivityDto = new ActivityDto
        {
            Title = "Title", Description = "Description"
        };

        public static List<ActivityDto> GetActivityDtoList = new List<ActivityDto>
        {
            new ActivityDto { Title = "", Description = "Description" }
        };

        public static Activity GetActivity = new Activity
        {
            Title = "Title", Description = "Description"
        };

        public static List<Activity> GetActivityList = new List<Activity>
        {
            new Activity { Title = "Title", Description = "Description" },
            new Activity { Title = "Title 2", Description = "Description 2" }
        };

        public static ActivityStatus GetActivityStatus = new ActivityStatus
        {
            Id = 1,
            Abbr = "STATUS"
        };

        public static ActivityType GetActivityType = new ActivityType
        {
            Id = 1,
            Abbr = "TYPE"
        };

        public static TimeSlot GetTimeSlot = new TimeSlot
        {
            Id = 1,
            Name = "Timeslot"
        };

        public static Edition GetEdition = new Edition
        {
            Id = 1,
        };
    }
}