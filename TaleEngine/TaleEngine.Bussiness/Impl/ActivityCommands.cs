using System;
using System.Collections.Generic;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Cross.Enums;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.CQRS.Impl
{
    public class ActivityCommands : IActivityCommands
    {
        private const int ACTIVITIESINHOME = 3;

        private readonly IActivityService _activityService;
        private readonly IActivityStatusService _activityStatusService;
        private readonly IActivityTypeService _activityTypesService;
        private readonly IEditionService _editionService;
        private readonly ITimeSlotService _timeSlotService;

        public ActivityCommands(IActivityService activityService,
            IActivityStatusService activityStatusService,
            IActivityTypeService activityTypeService,
            ITimeSlotService timeSlotService,
            IEditionService editionService)
        {
            _activityService = activityService ?? throw new ArgumentNullException(nameof(activityService));
            _activityStatusService = activityStatusService ?? throw new ArgumentNullException(nameof(activityStatusService));
            _activityTypesService = activityTypeService ?? throw new ArgumentNullException(nameof(activityTypeService));
            _editionService = editionService ?? throw new ArgumentNullException(nameof(editionService));
            _timeSlotService = timeSlotService ?? throw new ArgumentNullException(nameof(timeSlotService));
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


        // Commands

        public void DeleteCommand(int activityId)
        {
            _activityService.DeleteActivity(activityId);
        }

        public void CreateCommand(int editionId, ActivityDto activityDto)
        {
            var edition = _editionService.GetById(editionId);

            var type = _activityTypesService.GetById(activityDto.TypeId);
            var timeSlot = _timeSlotService.GetById(activityDto.TimeSlotId);
            var status = _activityStatusService.GetById((int)ActivityStatusEnum.PEN);

            var activity = new Activity()
                .SetTitle(activityDto.Title)
                .SetDescription(activityDto.Description)
                .SetPlaces(activityDto.Places)
                .SetImage(activityDto.Image)
                //.SetDates(activityDto.ActivityStart, activityDto.ActivityEnd)
                .SetStatus(status.Id)
                .SetTimeSlot(timeSlot)
                .SetType(type);

            _activityService.CreateActivity(editionId, activity);
        }

        public void UpdateCommand(ActivityDto activityDto)
        {
            var timeSlot = _timeSlotService.GetById(activityDto.TimeSlotId);

            var activity = new Activity()
                .SetTitle(activityDto.Title)
                .SetDescription(activityDto.Description)
                .SetPlaces(activityDto.Places)
                .SetImage(activityDto.Image)
                //.SetDates(activityDto.ActivityStart, activityDto.ActivityEnd)
                .SetTimeSlot(timeSlot);

            _activityService.UpdateActivity(activityDto.Id, activity);
        }

        public void ChangeActivityStatusCommand(int activityId, int statusId)
        {
            var activity = _activityService.GetById(activityId);
            var status = _activityStatusService.GetById(statusId);

            Activity model = ActivityMapper.MapEntityToModel(activity);

            model.SetStatus(status.Id);

            _activityService.UpdateActivity(activityId, model);
        }
    }
}