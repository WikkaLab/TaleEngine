using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class ActivityStatusService : IActivityStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityStatusService(IActivityStatusDomainService activityStatusDomainService)
        {
            _activityStatusDomainService = activityStatusDomainService;
        }

        public List<ActivityStatusDto> GetActivityStatuses()
        {
            var actStatuses = _activityStatusDomainService.GetAllActivityStatuses();

            var result = ActivityStatusMapper.Map(actStatuses);

            return result;
        }
    }
}
