using Moq;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Testing.Repositories
{
    public class ActivityTypeRepositoryMock
    {
        public Mock<IActivityTypeRepository> _activityStatusRepository;

        public ActivityTypeRepositoryMock()
        {
            _activityStatusRepository = new Mock<IActivityTypeRepository>();
            Setup();
        }

        private void Setup()
        {
            _activityStatusRepository.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(MockData.GetActivityType);
        }
    }
}
