using System.Collections.Generic;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.CQRS.Impl
{
    public class TimeSlotCommands : ITimeSlotCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public TimeSlotCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TimeSlotModel> GetAllTimeSlots()
        {
            var timeslots = _unitOfWork.TimeSlotRepository.GetAll();

            if (timeslots == null || timeslots.Count == 0)
            {
                return null;
            }

            var timeslotDtos = TimeSlotMapper.Map(timeslots);

            return timeslotDtos;
        }
    }
}
