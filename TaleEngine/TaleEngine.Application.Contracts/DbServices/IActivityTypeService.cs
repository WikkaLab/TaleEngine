using System.Collections.Generic;
using TaleEngine.Domain.Models;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IActivityTypeService
    {
        ActivityType GetById(int id);
        List<ActivityType> GetActivityTypes();
    }
}
