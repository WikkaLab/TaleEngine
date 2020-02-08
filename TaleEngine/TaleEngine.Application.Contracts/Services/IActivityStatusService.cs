using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;

namespace TaleEngine.Application.Contracts.Services
{
    public interface IActivityStatusService
    {
        List<ActivityStatusDto> GetActivityStatuses();
    }
}
