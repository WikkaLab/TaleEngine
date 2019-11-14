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

        public List<ActivityDto> GetActivities(int editionId)
        {
            return _activityDomainService.GetActivitiesOfEvent(editionId);
        }

        public List<ActivityDto> GetPendingActivities(int editionId)
        {
            return _activityDomainService.GetPendingActivities(editionId);
        }

        public int DeleteActivity(int activityId)
        {
            return _activityDomainService.DeleteActivity(activityId);
        }

        public int CreateActivity(int editionId, ActivityDto activityDto)
        {
            return _activityDomainService.CreateActivity(editionId, activityDto);
        }

        public int UpdateActivity(ActivityDto activityDto)
        {
            return _activityDomainService.UpdateActivity(activityDto);
        }
    }
}
