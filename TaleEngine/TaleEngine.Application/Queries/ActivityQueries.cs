using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Enums;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Application.Queries
{
    public class ActivityQueries
       : IActivityQueries
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IActivityStatusRepository _activityStatusRepository;

        public ActivityQueries(IActivityRepository activityRepository, IActivityStatusRepository activityStatusRepository)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
            _activityStatusRepository = activityStatusRepository ?? throw new ArgumentNullException(nameof(activityStatusRepository));
        }

        public List<ActivityModel> GetActivities(int editionId)
        {
            var activeStatus = _activityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            if (activeStatus == null)
            {
                return null;
            }

            var activities = _activityRepository
                .GetActivitiesByStatus(editionId, activeStatus.Id);

            var models = ActivityMapper.Map(activities);

            return models;
        }
    }
}