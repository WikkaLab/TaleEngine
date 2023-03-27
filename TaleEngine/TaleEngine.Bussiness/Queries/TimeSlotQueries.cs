using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class TimeSlotQueries : ITimeSlotQueries
    {
        private readonly ITimeSlotService _service;

        public TimeSlotQueries(ITimeSlotService service)
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
