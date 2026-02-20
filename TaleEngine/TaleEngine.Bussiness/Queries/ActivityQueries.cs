using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class ActivityQueries : IActivityQueries
    {
        private const int ACTIVITIESPERPAGE = 3;

        private readonly IActivityService _activityService;
        private readonly IEditionService _editionService;

        public ActivityQueries(IActivityService activityService, IEditionService editionService)
        {
            _activityService = activityService ?? throw new ArgumentNullException(nameof(activityService));
            _editionService = editionService ?? throw new ArgumentNullException(nameof(editionService));
        }

        public List<ActivityDto> ActiveActivitiesQuery(int editionId)
        {
            var activities = _activityService
                .GetActiveActivities(editionId);

            var models = ActivityMapper.MapEntityToDto(activities);

            return models;
        }

        public List<ActivityDto> PendingActivitiesQuery(int editionId)
        {
            var activities = _activityService
                .GetPendingActivities(editionId);

            var models = ActivityMapper.MapEntityToDto(activities);

            return models;
        }

        public ActivityFilteredResult ActiveActivitiesFilteredQuery(ActivityFilterRequest request, int userId = default)
        {
            var currentEdition = _editionService.GetById(request.EditionId);

            if (currentEdition == null)
            {
                return null;
            }

            int skipByPagination = request.Page * ACTIVITIESPERPAGE;

            var activitiesQueried = _activityService.GetActiveActivitiesFiltered(request.TypeId, currentEdition.Id,
                request.TimeFrames, request.Title, skipByPagination, ACTIVITIESPERPAGE, userId);

            var totalActivities = activitiesQueried.Count();
            var activities = activitiesQueried.ToList();

            var models = ActivityMapper.MapEntityToDto(activities);

            var totalPages = (int)Math.Ceiling((double)totalActivities / ACTIVITIESPERPAGE);

            var result = new ActivityFilteredResult
            {
                Activities = models,
                CurrentPage = request.Page,
                TotalPages = totalPages
            };

            return result;
        }

        public List<ActivityDto> LastThreeActivitiesQuery(int edition)
        {
            var activities = _activityService
                 .GetLastThreeActivities(edition);

            var result = ActivityMapper.MapEntityToDto(activities);

            return result;
        }
    }
}
