using Moq;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Testing.Repositories
{
    public class ActivityRepositoryMock
    {
        public Mock<IActivityRepository> _activityRepository;

        public ActivityRepositoryMock()
        {
            _activityRepository = new Mock<IActivityRepository>();
            Setup();
        }

        private void Setup()
        {
            _activityRepository.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(MockData.GetActivity);
            _activityRepository.Setup(m => m.GetEventActivities(It.IsAny<int>()))
                .Returns(MockData.GetActivityList);
            _activityRepository.Setup(m => m.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(MockData.GetActivityList);
        }
    }
}
