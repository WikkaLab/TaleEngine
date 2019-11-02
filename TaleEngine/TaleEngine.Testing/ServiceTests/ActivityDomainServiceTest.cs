using NUnit.Framework;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.DomainServices;

namespace TaleEngine.Testing
{
    public class ActivityDomainServiceTest
    {
        private static IActivityDomainService _activityService;

        private static UnitOfWorkMock _unitOfWorkMock;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new UnitOfWorkMock();
            _activityService = new ActivityDomainService(_unitOfWorkMock._unitOfWork.Object);
        }

        [Test]
        public void CreateActivityTest()
        {
            var editionId = 1;
            var activityDto = new ActivityDto
            {
                Title = "Title",
                Description = "Description",
                Image = "URL",
                Places = 3,
                TimeSlotId = 1,
                TypeId = 1
            };

            var result =_activityService.CreateActivity(editionId, activityDto);

            Assert.IsTrue(result == 1, "CreateActivity() is not 1");
        }

        [Test]
        public void GetAllActivities()
        {
            var result = _activityService.GetActivitiesOfEvent();

            Assert.IsNotNull(result, "GetActivities() results null");
            Assert.IsTrue(result.Count == 2, "GetActivities() is not 2");
        }
    }
}