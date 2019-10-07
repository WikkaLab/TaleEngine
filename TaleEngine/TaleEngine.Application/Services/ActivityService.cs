using System.Collections.Generic;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityDomainService _activityDomainService;

        public ActivityService(IActivityDomainService activityDomainService)
        {
            _activityDomainService = activityDomainService;
        }

        public List<ActivityDto> GetActivities()
        {
            return _activityDomainService.GetActivitiesOfEvent();
        }
    }
}
