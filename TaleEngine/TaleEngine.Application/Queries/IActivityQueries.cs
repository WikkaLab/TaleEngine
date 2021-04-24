using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Queries
{
    public interface IActivityQueries
    {
        List<ActivityModel> GetActivities(int editionId);
    }
}