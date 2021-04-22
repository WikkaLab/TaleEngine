using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Bussiness.DomainServices
{
    public class TimeSlotDomainService : ITimeSlotDomainService
    {
        private readonly ITimeSlotRepository _timeSlotRepository;

        public TimeSlotDomainService(ITimeSlotRepository timeSlotRepository)
        {
            _timeSlotRepository = timeSlotRepository ?? throw new ArgumentNullException(nameof(timeSlotRepository));
        }

        public List<TimeSlotModel> GetAllTimeSlots()
        {
            var timeslots = _timeSlotRepository.GetAll();

            if (timeslots == null || timeslots.Count == 0)
            {
                return null;
            }

            var timeslotDtos = TimeSlotMapper.Map(timeslots);

            return timeslotDtos;
        }
    }
}