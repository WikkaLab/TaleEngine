using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class ActivityStatusService : IActivityStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ActivityStatusEntity> GetActivityStatuses()
        {
            var result = _unitOfWork.ActivityStatusRepository
                .GetAll();

            return result;
        }

        public ActivityStatusEntity GetById(int statusId)
        {
            var result = _unitOfWork.ActivityStatusRepository
                .GetById(statusId);

            return result;
        }
    }
}
