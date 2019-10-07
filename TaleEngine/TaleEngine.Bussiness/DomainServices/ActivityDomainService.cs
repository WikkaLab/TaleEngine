using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Bussiness.DomainServices
{
    public class ActivityDomainService : IActivityDomainService
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityDomainService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public List<ActivityDto> GetActivitiesOfEvent()
        {
            var activities = _activityRepository.GetEventActivities(1);

            var activityDtos = new List<ActivityDto>();

            foreach (var act in activities)
            {
                activityDtos.Add(ActivityMapper.Map(act));
            }

            return activityDtos;
        }
    }
}
