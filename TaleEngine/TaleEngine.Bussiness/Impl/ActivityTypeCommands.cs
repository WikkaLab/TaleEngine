using System.Collections.Generic;
using TaleEngine.Commands.Contracts;

namespace TaleEngine.Commands.Impl
{
    public class ActivityTypeCommands : IActivityTypeCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityTypeCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ActivityTypeDto> GetAllActivityTypes()
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
