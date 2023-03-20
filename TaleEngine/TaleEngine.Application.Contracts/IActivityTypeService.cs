using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface IActivityTypeService
    {
        ActivityTypeEntity GetById(int id);
        List<ActivityTypeEntity> GetActivityTypes();
    }
}
