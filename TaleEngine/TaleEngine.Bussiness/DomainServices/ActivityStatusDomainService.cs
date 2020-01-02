using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts;

namespace TaleEngine.Bussiness.DomainServices
{
    public class ActivityStatusDomainService : IActivityStatusDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityStatusDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ActivityStatusDto> GetAllActivityStatuses()
        {
            var allStatuses = _unitOfWork.ActivityStatusRepository.GetAll();

            var activityStatusDtos = new List<ActivityStatusDto>();

            foreach (var status in allStatuses)
            {
                activityStatusDtos.Add(ActivityStatusMapper.Map(status));
            }

            return activityStatusDtos;
        }
    }
}
