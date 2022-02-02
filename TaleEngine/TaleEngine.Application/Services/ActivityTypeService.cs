using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

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
