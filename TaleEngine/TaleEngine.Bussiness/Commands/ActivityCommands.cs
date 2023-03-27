using System;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.API.Contracts.Dtos;
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
    }
}