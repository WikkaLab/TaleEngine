using System;
using System.Linq;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Cross.Enums;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Commands
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
                .SetTimeSlot(timeSlot.Id)
                .SetType(type.Id);

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
                .SetTimeSlot(timeSlot.Id);

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

        public ActivityEnrollmentResult EnrollInActivityCommand(ActivityEnrollmentRequest request)
        {
            var activity = _activityService.GetById(request.ActivityId);
            
            if (activity == null)
            {
                return new ActivityEnrollmentResult
                {
                    Success = false,
                    Message = "Activity not found",
                    ActivityId = request.ActivityId,
                    UserId = request.UserId
                };
            }

            var success = _activityService.EnrollUserInActivity(request.ActivityId, request.UserId);
            
            if (!success)
            {
                return new ActivityEnrollmentResult
                {
                    Success = false,
                    Message = "Enrollment failed. User may already be enrolled or in waiting list.",
                    ActivityId = request.ActivityId,
                    UserId = request.UserId
                };
            }

            // Get updated activity to check enrollment status
            var updatedActivity = _activityService.GetById(request.ActivityId);
            var enrolledUsers = updatedActivity.UsersPlay?.Count ?? 0;
            var isWaitingList = enrolledUsers >= activity.Places;
            var position = isWaitingList ? _activityService.GetUserPositionInWaitingList(request.ActivityId, request.UserId) : null;

            return new ActivityEnrollmentResult
            {
                Success = true,
                ActivityId = request.ActivityId,
                UserId = request.UserId,
                IsWaitingList = isWaitingList,
                PositionInWaitingList = position,
                AvailablePlaces = activity.Places - enrolledUsers,
                TotalPlaces = activity.Places,
                Message = isWaitingList 
                    ? $"Added to waiting list at position {position}" 
                    : "Successfully enrolled in activity"
            };
        }

        public bool LeaveActivityCommand(ActivityEnrollmentRequest request)
        {
            return _activityService.RemoveUserFromActivity(request.ActivityId, request.UserId);
        }
    }
}