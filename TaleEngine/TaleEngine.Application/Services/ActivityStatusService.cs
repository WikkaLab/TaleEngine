using System.Collections.Generic;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Application.Services
{
    public class ActivityStatusService : IActivityStatusService
    {
        private IActivityStatusDomainService _activityStatusDomainService;

        public ActivityStatusService(IActivityStatusDomainService activityStatusDomainService)
        {
            _activityStatusDomainService = activityStatusDomainService;
        }

        public List<ActivityStatusDto> GetActivityStatuses()
        {
            return _activityStatusDomainService.GetAllActivityStatuses();
        }
    }
}
