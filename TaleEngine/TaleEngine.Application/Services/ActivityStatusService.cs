using System.Collections.Generic;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Mappers;

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
            var actStatuses = _activityStatusDomainService.GetAllActivityStatuses();

            var result = new List<ActivityStatusDto>();

            foreach (var aS in actStatuses)
            {
                result.Add(ActivityStatusMapper.Map(aS));
            }

            return result;
        }
    }
}
