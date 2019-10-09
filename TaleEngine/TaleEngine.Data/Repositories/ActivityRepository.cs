using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IDatabaseContext _context;

        //private readonly List<Activity> _activities;

        public ActivityRepository(IDatabaseContext context)
        {
            //_activities = MockActivityData.GetActivities();
            _context = context;
        }

        public List<Activity> GetEventActivities(int eventId)
        {
            return _context.Activities
                //.Where(a => a.EventId == eventId)
                .ToList();
        }

        public Activity GetSelectedActivity(int activityId)
        {
            return _context.Activities.FirstOrDefault(a => a.Id == activityId);
        }
    }
}
