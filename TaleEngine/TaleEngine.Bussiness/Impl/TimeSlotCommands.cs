using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.CQRS.Impl
{
    public class TimeSlotCommands : ITimeSlotCommands
    {
        private readonly ITimeSlotService _service;

        public TimeSlotCommands(ITimeSlotService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public List<TimeSlotDto> AllTimeSlotsQuery()
        {
            var timeslots = _service.GetTimeSlots();

            if (timeslots == null || timeslots.Count == 0)
            {
                return null;
            }

            var timeslotDtos = TimeSlotMapper.Map(timeslots);

            return timeslotDtos;
        }
    }
}
