using Moq;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Testing.Repositories
{
    public class ActivityStatusRepositoryMock
    {
        public Mock<IActivityStatusRepository> _activityStatusRepository;

        public ActivityStatusRepositoryMock()
        {
            _activityStatusRepository = new Mock<IActivityStatusRepository>();
            Setup();
        }

        private void Setup()
        {
            _activityStatusRepository.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(MockData.GetActivityStatus);
        }
    }
}
