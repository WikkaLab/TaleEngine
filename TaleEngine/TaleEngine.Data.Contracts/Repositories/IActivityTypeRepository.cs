using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface IActivityTypeRepository
    {
        List<ActivityType> GetActivityTypes();
    }
}
