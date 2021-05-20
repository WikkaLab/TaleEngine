using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Mappers;
using TaleEngine.Bussiness.Contracts.DomainServices;

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

            var result = ActivityTypeMapper.Map(actTypes);

            return result;
        }
    }
}
