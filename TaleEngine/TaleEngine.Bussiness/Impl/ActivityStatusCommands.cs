using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.CQRS.Impl
{
    public class ActivityStatusCommands : IActivityStatusCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityStatusCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ActivityStatusDto> GetAllActivityStatuses()
        {
            var allStatuses = _unitOfWork.ActivityStatusRepository.GetAll();

            if (allStatuses == null || allStatuses.Count == 0)
            {
                return null;
            }

            var models = ActivityStatusMapper.Map(allStatuses);

            return models;
        }
    }
}
