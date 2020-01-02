using System.Collections.Generic;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Dtos.Requests;

namespace TaleEngine.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityDomainService _activityDomainService;

        public ActivityService(IActivityDomainService activityDomainService)
        {
            _activityDomainService = activityDomainService;
        }

        public List<ActivityDto> GetActiveActivities(int editionId)
        {
            return _activityDomainService.GetActiveActivities(editionId);
        }

        public List<ActivityDto> GetPendingActivities(int editionId)
        {
            return _activityDomainService.GetPendingActivities(editionId);
        }

        public List<ActivityDto> GetActiveActivitiesFiltered(ActivityFilterRequest activityFilterRequest)
        {
            return _activityDomainService
                .GetActiveActivitiesFiltered(activityFilterRequest.TypeId,
                activityFilterRequest.EditionId,
                activityFilterRequest.Title,
                activityFilterRequest.CurrentPage);
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

        public int ChangeActivityStatus(ActivityChangeStatusDto activityChangeStatusDto)
        {
            return _activityDomainService
                .ChangeActivityStatus(activityChangeStatusDto.ActivityId, activityChangeStatusDto.StatusId);
        }

        
    }
}
