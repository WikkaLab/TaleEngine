using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;

namespace TaleEngine.Application.Contracts.Services
{
    public interface IActivityTypeService
    {
        List<ActivityTypeDto> GetActivityTypes();
    }
}
