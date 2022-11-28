using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.CQRS.Queries
{
    public class ActivityQueries : IActivityQueries
    {
        private const int ACTIVITIESINHOME = 3;

        private readonly IActivityService _activityService;

        public ActivityQueries(IActivityService activityService)
        {
            _activityService = activityService ?? throw new ArgumentNullException(nameof(activityService));
        }

        // Queries

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

        public ActivityFilteredResult ActiveActivitiesFilteredQuery(ActivityFilterRequest request)
        {
            throw new NotImplementedException();

            //int activitiesPerPage = 10;

            //var activeStatus = _activityStatusService
            //    .GetById((int)ActivityStatusEnum.ACT);

            //var currentEdition = _editionService.GetById(request.EditionId);

            //if (currentEdition == null || activeStatus == null)
            //{
            //    return null;
            //}

            //int skipByPagination = (request.CurrentPage - 1) * activitiesPerPage;

            //var activities = _activityService
            //    .GetActiveActivitiesFiltered(activeStatus.Id, request.TypeId, currentEdition.Id,
            //        request.Title, skipByPagination, activitiesPerPage);

            //var models = ActivityMapper.Map(activities);

            //int totalActivities = _activityService
            //    .GetTotalActivities(activeStatus.Id, request.TypeId, currentEdition.Id, request.Title);

            //double actsPerPage = totalActivities / activitiesPerPage;
            //var totalPages = (int)Math.Ceiling(actsPerPage);

            //var result = new ActivityFilteredResult
            //{
            //    Activities = models,
            //    CurrentPage = currentPage,
            //    TotalPages = totalPages
            //};

            //return result;
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
