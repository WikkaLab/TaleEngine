using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Results;
using TaleEngine.Commands.Contracts;
using TaleEngine.Commands.Enums;
using TaleEngine.Commands.Mappers;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.Commands.Impl
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

        public List<ActivityDto> ActiveActivitiesQuery(int editionId)
        {
            var activities = _activityService
                .GetActiveActivities(editionId);

            var models = ActivityMapper.Map(activities);

            return models;
        }

        public List<ActivityDto> PendingActivitiesQuery(int editionId)
        {
            var activities = _activityService
                .GetPendingActivities(editionId);

            var models = ActivityMapper.Map(activities);

            return models;
        }

        public int DeleteCommand(int activityId)
        {
            // Validate 

            try
            {
                _activityService.DeleteActivity(activityId);
            }
            catch (Exception)
            {
                return 0;
            }

            return 1;
        }

        public int CreateCommand(int editionId, ActivityDto activityDto)
        {
            var isValidData = ValidateNewActivityData(activityDto, editionId);

            if (!isValidData)
            {
                return 0;
            }

            var status = _activityStatusService.GetById((int)ActivityStatusEnum.PEN);
            activityDto.StatusId = status.Id;

            var activity = ActivityMapper.Map(activityDto);

            _activityService.CreateActivity(editionId, activity);

            return 1;
        }

        public int UpdateCommand(ActivityDto activityDto)
        {
            //var isValidData = ValidateNewActivityData(activityDto, editionId);

            //if (!isValidData)
            //{
            //    return 0;
            //}

            var activity = ActivityMapper.Map(activityDto);

            _activityService.UpdateActivity(activity);

            return 1;
        }

        private bool ValidateNewActivityData(ActivityDto model, int editionId)
        {
            var edition = _editionService.GetById(editionId);
            if (edition == null)
            {
                return false;
            }

            if (model.Places <= 0)
            {
                return false;
            }

            var type = _activityTypesService.GetById(model.TypeId);
            if (type == null)
            {
                return false;
            }

            var timeSlot = _timeSlotService.GetById(model.TimeSlotId);
            if (timeSlot == null)
            {
                return false;
            }

            return true;
        }

        public int ChangeActivityStatusCommand(int activityId, int statusId)
        {
            var status = _activityStatusService.GetById(statusId);
            var activity = _activityService.GetById(activityId);

            if (status == null || activity == null)
            {
                return 0;
            }

            activity.StatusId = status.Id;

            return _activityService.UpdateActivity(activity);

            return 1;
        }

        public ActivityFilteredResult GetActiveActivitiesFiltered(int type, int edition,
            string title, int currentPage)
        {
            throw new NotImplementedException();

            //    int activitiesPerPage = 10;

            //    var activeStatus = _activityStatusService
            //        .GetById((int)ActivityStatusEnum.ACT);

            //    var currentEdition = _editionService.GetById(edition);

            //    if (currentEdition == null || activeStatus == null)
            //    {
            //        return null;
            //    }

            //    int skipByPagination = (currentPage - 1) * activitiesPerPage;

            //    var activities = _activityService
            //        .GetActiveActivitiesFiltered(activeStatus.Id, type, currentEdition.Id,
            //            title, skipByPagination, activitiesPerPage);

            //    var models = ActivityMapper.Map(activities);

            //    int totalActivities = _activityService
            //        .GetTotalActivities(activeStatus.Id, type, currentEdition.Id, title);

            //    double actsPerPage = totalActivities / activitiesPerPage;
            //    var totalPages = (int)Math.Ceiling(actsPerPage);

            //    var result = new ActivityFilteredResultDto
            //    {
            //        Activities = models,
            //        CurrentPage = currentPage,
            //        TotalPages = totalPages
            //    };

            //    return result;
        }

        public List<ActivityDto> LastThreeActivitiesQuery(int edition)
        {
            var activities = _activityService
                 .GetLastThreeActivities(edition);

            if (activities == null || activities.Count == 0)
            {
                return null;
            }

            var models = ActivityMapper.Map(activities);

            return models;
        }

    }
}