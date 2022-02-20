using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IActivityStatusService
    {
        ActivityStatusEntity GetById(int statusId);
        List<ActivityStatusEntity> GetActivityStatuses();
    }
}
