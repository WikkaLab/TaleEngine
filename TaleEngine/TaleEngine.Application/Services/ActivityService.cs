using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Dtos.Requests;
using TaleEngine.Application.Contracts.Dtos.Results;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Mappers;
using TaleEngine.Bussiness.Contracts.DomainServices;

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
            var activities = _activityDomainService.GetActiveActivities(editionId);

            var result = ActivityMapper.Map(activities);

            return result;
        }

        public List<ActivityDto> GetPendingActivities(int editionId)
        {
            var penActivities = _activityDomainService.GetPendingActivities(editionId);

            var result = ActivityMapper.Map(penActivities);

            return result;
        }

        public ActivityFilteredResult GetActiveActivitiesFiltered(ActivityFilterRequest activityFilterRequest)
        {
            var filtered = _activityDomainService
                .GetActiveActivitiesFiltered(activityFilterRequest.TypeId,
                activityFilterRequest.EditionId,
                activityFilterRequest.Title,
                activityFilterRequest.CurrentPage);

            return ActivityFilteredMapper.Map(filtered);
        }

        public int DeleteActivity(int activityId)
        {
            return _activityDomainService.DeleteActivity(activityId);
        }

        public int CreateActivity(int editionId, ActivityDto activityDto)
        {
            var activityModel = ActivityMapper.Map(activityDto);

            var result = _activityDomainService.CreateActivity(editionId, activityModel);
            return result;
        }

        public int UpdateActivity(ActivityDto activityDto)
        {
            var activityModel = ActivityMapper.Map(activityDto);

            return _activityDomainService.UpdateActivity(activityModel);
        }

        public int ChangeActivityStatus(ActivityChangeStatusDto activityChangeStatusDto)
        {
            return _activityDomainService
                .ChangeActivityStatus(activityChangeStatusDto.ActivityId, activityChangeStatusDto.StatusId);
        }

        public List<ActivityDto> GetLastThreeActivities(int editionId)
        {
            var activities = _activityDomainService.GetLastThreeActivities(editionId);

            var dtos = ActivityMapper.Map(activities);

            return dtos;
        }
    }
}
