using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IActivityTypeService
    {
        ActivityTypeEntity GetById(int id);
        List<ActivityTypeEntity> GetActivityTypes();
    }
}
