using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Bussiness.DomainServices
{
    public class ActivityStatusDomainService : IActivityStatusDomainService
    {
        private readonly IActivityStatusRepository _activityStatusRepository;

        public ActivityStatusDomainService(IActivityStatusRepository activityStatusRepository)
        {
            _activityStatusRepository = activityStatusRepository ?? throw new ArgumentNullException(nameof(activityStatusRepository));
        }

        public List<ActivityStatusModel> GetAllActivityStatuses()
        {
            var allStatuses = _activityStatusRepository.GetAll();

            if (allStatuses == null || allStatuses.Count == 0)
            {
                return null;
            }

            var models = ActivityStatusMapper.Map(allStatuses);

            return models;
        }
    }
}