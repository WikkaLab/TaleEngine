using System.Collections.Generic;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Mappers;

namespace TaleEngine.Application.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IActivityTypeDomainService _activityTypeDomainService;

        public ActivityTypeService(IActivityTypeDomainService activityTypeDomainService)
        {
            _activityTypeDomainService = activityTypeDomainService;
        }

        public List<ActivityTypeDto> GetActivityTypes()
        {
            var actTypes = _activityTypeDomainService.GetAllActivityTypes();

            var result = new List<ActivityTypeDto>();

            foreach (var aT in actTypes)
            {
                result.Add(ActivityTypeMapper.Map(aT));
            }

            return result;
        }
    }
}
