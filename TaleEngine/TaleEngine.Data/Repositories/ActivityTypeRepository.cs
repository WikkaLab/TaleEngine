using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Data;

namespace TaleEngine.Data.Repositories
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly List<ActivityType> _activityTypes;

        public ActivityTypeRepository()
        {
            _activityTypes = MockActivityTypeData.GetActivityTypes();
        }

        public List<ActivityType> GetActivityTypes()
        {
            return _activityTypes;
        }
    }
}
