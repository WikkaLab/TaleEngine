using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface IActivityStatusService
    {
        ActivityStatusEntity GetById(int statusId);
        List<ActivityStatusEntity> GetActivityStatuses();
    }
}
