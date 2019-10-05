using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Data;

namespace TaleEngine.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly List<Activity> _activities;

        public ActivityRepository()
        {
            _activities = MockActivityData.GetActivities();
        }

        public List<Activity> GetEventActivities(int eventId)
        {
            return _activities.Where(a => a.EventId == eventId).ToList();
        }

        public Activity GetSelectedActivity(int activityId)
        {
            return _activities.FirstOrDefault(a => a.Id == activityId);
        }
    }
}
