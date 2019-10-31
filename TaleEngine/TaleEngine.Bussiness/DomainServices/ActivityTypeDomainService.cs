using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts;

namespace TaleEngine.Bussiness.DomainServices
{
    public class ActivityTypeDomainService : IActivityTypeDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityTypeDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ActivityTypeDto> GetAllActivityTypes()
        {
            var activityTypes = _unitOfWork.ActivityTypeRepository.GetAll();

            var activityTypeDtos = new List<ActivityTypeDto>();

            foreach (var type in activityTypes)
            {
                activityTypeDtos.Add(ActivityTypeMapper.Map(type));
            }

            return activityTypeDtos;
        }
    }
}
