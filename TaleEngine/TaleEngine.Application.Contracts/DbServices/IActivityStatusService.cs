using System.Collections.Generic;
using TaleEngine.Domain.Models;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IActivityStatusService
    {
        ActivityStatus GetById(int statusId);
        List<ActivityStatus> GetActivityStatuses();
    }
}
