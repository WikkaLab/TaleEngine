using Moq;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Testing.Repositories
{
    public class TimeSlotRepositoryMock
    {
        public Mock<ITimeSlotRepository> _timeSlotRepository;

        public TimeSlotRepositoryMock()
        {
            _timeSlotRepository = new Mock<ITimeSlotRepository>();
            Setup();
        }

        private void Setup()
        {
            _timeSlotRepository.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(MockData.GetTimeSlot);
        }
    }
}
