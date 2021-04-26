using System;
using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Mappers;
using TaleEngine.Bussiness.Contracts.DomainServices;

namespace TaleEngine.Application.Services
{
    public class ActivityStatusService : IActivityStatusService
    {
        private IActivityStatusDomainService _activityStatusDomainService;

        public ActivityStatusService(IActivityStatusDomainService activityStatusDomainService)
        {
            _activityStatusDomainService = activityStatusDomainService ?? throw new ArgumentNullException(nameof(activityStatusDomainService));
        }

        public List<ActivityStatusDto> GetActivityStatuses()
        {
            var actStatuses = _activityStatusDomainService.GetAllActivityStatuses();

            var result = ActivityStatusMapper.Map(actStatuses);

            return result;
        }
    }
}