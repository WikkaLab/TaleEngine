using Moq;
using TaleEngine.Data.Contracts;
using TaleEngine.Testing.Repositories;

namespace TaleEngine.Testing
{
    public class UnitOfWorkMock
    {
        public Mock<IUnitOfWork> _unitOfWork;

        public UnitOfWorkMock()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            Setup();
        }

        private void Setup()
        {
            var activityRepository = new ActivityRepositoryMock();
            var editionRepository = new EditionRepositoryMock();
            var timeSlotRepository = new TimeSlotRepositoryMock();
            var activityStatusRepository = new ActivityStatusRepositoryMock();
            var activityTypeRepository = new ActivityTypeRepositoryMock();

            _unitOfWork.Setup(m => m.ActivityRepository)
                .Returns(activityRepository._activityRepository.Object);
            _unitOfWork.Setup(m => m.EditionRepository)
                .Returns(editionRepository._editionRepository.Object);
            _unitOfWork.Setup(m => m.TimeSlotRepository)
                .Returns(timeSlotRepository._timeSlotRepository.Object);
            _unitOfWork.Setup(m => m.ActivityStatusRepository)
                .Returns(activityStatusRepository._activityStatusRepository.Object);
            _unitOfWork.Setup(m => m.ActivityTypeRepository)
                .Returns(activityTypeRepository._activityStatusRepository.Object);
        }
    }
}
