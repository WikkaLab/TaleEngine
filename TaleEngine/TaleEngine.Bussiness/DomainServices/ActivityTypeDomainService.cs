using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
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

        public List<ActivityTypeModel> GetAllActivityTypes()
        {
            var activityTypes = _unitOfWork.ActivityTypeRepository.GetAll();

            if (activityTypes == null || activityTypes.Count == 0)
            {
                return null;
            }

            var models = ActivityTypeMapper.Map(activityTypes);

            return models;
        }
    }
}
