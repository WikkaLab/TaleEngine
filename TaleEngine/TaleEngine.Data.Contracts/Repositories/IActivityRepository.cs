using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface IActivityRepository
    {
        List<Activity> GetEventActivities(int eventId);
        Activity GetSelectedActivity(int activityId);
    }
}
