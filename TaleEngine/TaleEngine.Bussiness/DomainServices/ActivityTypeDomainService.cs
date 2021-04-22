using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Bussiness.DomainServices
{
    public class ActivityTypeDomainService : IActivityTypeDomainService
    {
        private readonly IActivityTypeRepository _activityTypeRepository;

        public ActivityTypeDomainService(IActivityTypeRepository activityTypeRepository)
        {
            _activityTypeRepository = activityTypeRepository ?? throw new ArgumentNullException(nameof(activityTypeRepository));
        }

        public List<ActivityTypeModel> GetAllActivityTypes()
        {
            var activityTypes = _activityTypeRepository.GetAll();

            if (activityTypes == null || activityTypes.Count == 0)
            {
                return null;
            }

            var models = ActivityTypeMapper.Map(activityTypes);

            return models;
        }
    }
}