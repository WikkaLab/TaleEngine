using System.Collections.Generic;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;

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
            return _activityTypeDomainService.GetAllActivityTypes();
        }
    }
}
