using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;

namespace TaleEngine.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ActivityTypeEntity> GetActivityTypes()
        {
            var result = _unitOfWork.ActivityTypeRepository
                .GetAll();

            return result;
        }

        public ActivityTypeEntity GetById(int typeId)
        {
            var result = _unitOfWork.ActivityTypeRepository
                .GetById(typeId);

            return result;
        }
    }
}
