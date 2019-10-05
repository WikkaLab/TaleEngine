using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Data;

namespace TaleEngine.Data.Repositories
{
    public class ActivityStatusRepository : IActivityStatusRepository
    {
        private readonly List<ActivityStatus> _activityStatuses;

        public ActivityStatusRepository()
        {
            _activityStatuses = MockActivityStatusData.GetActivityStatuses();
        }

        public List<ActivityStatus> GetActivityStatuses()
        {
            return _activityStatuses;
        }
    }
}
