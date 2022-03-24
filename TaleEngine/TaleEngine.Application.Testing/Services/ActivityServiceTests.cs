using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Services;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.DbServices.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class ActivityServiceTests
    {
        private Mock<IUnitOfWork> mock;

        public ActivityServiceTests()
        {
            mock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void GetActiveActivities_Success()
        {
            // Arrange
            int editionId = 1;
            var list = ActivityBuilder.BuildActivityList();

            mock.Setup(x => x.ActivityRepository.GetAll())
                .Returns(list);

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.GetActiveActivities(editionId);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            mock.Verify(x => x.ActivityRepository.GetAll(),
                Times.Once);
        }

        [Fact]
        public void GetActiveActivities_IdIsZero_ShouldReturnNull()
        {
            // Arrange
            int editionId = 0;
            List<ActivityEntity> models = null;
            mock.Setup(x => x.ActivityRepository.GetAll())
                .Returns(models);

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.GetActiveActivities(editionId);

            // Assert
            result.Should().BeNull();
            mock.Verify(x => x.ActivityRepository.GetAll(),
                Times.Once);
        }

        [Fact]
        public void GetPendingActivities_Success()
        {
            // Arrange
            int editionId = 1;
            var list = ActivityBuilder.BuildActivityList();
            mock.Setup(x => x.ActivityRepository.GetAll())
                .Returns(list);

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.GetPendingActivities(editionId);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            mock.Verify(x => x.ActivityRepository.GetAll(),
                Times.Once);
        }

        [Fact]
        public void GetPendingActivities_IdIsZero_ShouldReturnNull()
        {
            // Arrange
            int editionId = 0;
            List<ActivityEntity> models = null;
            mock.Setup(x => x.ActivityRepository.GetAll())
                .Returns(models);

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.GetPendingActivities(editionId);

            // Assert
            result.Should().BeNull();
            mock.Verify(x => x.ActivityRepository.GetAll(),
                Times.Once);
        }

        [Fact]
        public void DeleteActivity_Success()
        {
            // Arrange
            int activityId = 1;

            mock.Setup(x => x.ActivityRepository.Delete(activityId))
                .Verifiable();

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.DeleteActivity(activityId);

            // Assert
            result.Should().Be(0);
            mock.Verify(x => x.ActivityRepository.Delete(It.IsAny<int>()),
                Times.Once);
        }

        [Fact]
        public void CreateActivity_Success()
        {
            // Arrange
            int editionId = 1;
            Activity aggr = new();

            mock.Setup(x => x.ActivityRepository.Insert(It.IsAny<ActivityEntity>()))
                .Verifiable();

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.CreateActivity(editionId, aggr);

            // Assert
            result.Should().Be(1);
            mock.Verify(x => x.ActivityRepository.Insert(It.IsAny<ActivityEntity>()),
                Times.Once);
        }

        [Fact]
        public void CreateActivity_DtoIsNull_ShouldReturnZero()
        {
            // Arrange
            int editionId = 1;
            Activity aggr = null;

            mock.Setup(x => x.ActivityRepository.Insert(It.IsAny<ActivityEntity>()))
                .Verifiable();

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.CreateActivity(editionId, aggr);

            // Assert
            result.Should().Be(0);
            mock.Verify(x => x.ActivityRepository.Insert(It.IsAny<ActivityEntity>()),
                Times.Once);
        }

        [Fact]
        public void UpdateActivity_Success()
        {
            // Arrange
            int id = 1;
            Activity aggr = new();

            mock.Setup(x => x.ActivityRepository.Update(It.IsAny<ActivityEntity>()))
                .Verifiable();

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.UpdateActivity(id, aggr);

            // Assert
            result.Should().Be(1);
            mock.Verify(x => x.ActivityRepository.Update(It.IsAny<ActivityEntity>()),
                Times.Once);
        }

        [Fact]
        public void UpdateActivity_DtoIsNull_ShouldReturnZero()
        {
            // Arrange
            int id = 0;
            Activity activityDto = null;

            mock.Setup(x => x.ActivityRepository.Update(It.IsAny<ActivityEntity>()))
                .Verifiable();

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.UpdateActivity(id, activityDto);

            // Assert
            result.Should().Be(0);
            mock.Verify(x => x.ActivityRepository.Update(It.IsAny<ActivityEntity>()),
                Times.Once);
        }

        //[Fact]
        //public void GetActiveActivitiesFiltered_Success()
        //{
        //    // Arrange
        //    var request = ActivityBuilder.BuildActivityFilterRequest();
        //    var resultModel = ActivityModelBuilder.BuildActivityFilteredResultModel();

        //    mock.Setup(x => x.GetActiveActivitiesFiltered(request.TypeId,
        //        request.EditionId, request.Title, request.CurrentPage))
        //        .Returns(resultModel);

        //    var target = new ActivityService(mock.Object);

        //    // Act
        //    var result = target.GetActiveActivitiesFiltered(request);

        //    // Assert
        //    result.Should().NotBeNull();
        //    result.Activities.Should().NotBeNull();
        //    result.Activities.Should().NotBeEmpty();
        //    mock.Verify(x => x.GetActiveActivitiesFiltered(It.IsAny<int>(),
        //        It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()),
        //        Times.Once);
        //}

        [Fact]
        public void ChangeActivityStatus_Success()
        {
            // Arrange
            int id = 1;
            int status = 1;

            mock.Setup(x => x.ActivityRepository.Update(It.IsAny<ActivityEntity>()))
                .Verifiable();

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.ChangeActivityStatus(id, status);

            // Assert
            result.Should().Be(1);
            mock.Verify(x => x.ActivityRepository.Update(It.IsAny<ActivityEntity>()),
                Times.Once);
        }

        [Fact]
        public void GetLastThreeActivities_Success()
        {
            // Arrange
            int editionId = 1;
            var list = ActivityBuilder.BuildActivityList();
            mock.Setup(x => x.ActivityRepository.GetEventActivities(editionId))
                .Returns(list);

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.GetLastThreeActivities(editionId);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            mock.Verify(x => x.ActivityRepository.GetAll(),
                Times.Once);
        }

        [Fact]
        public void GetLastThreeActivities_IdIsZero_ShouldReturnNull()
        {
            // Arrange
            int editionId = 0;
            List<ActivityEntity> models = null;
            mock.Setup(x => x.ActivityRepository.GetAll())
                .Returns(models);

            var target = new ActivityService(mock.Object);

            // Act
            var result = target.GetLastThreeActivities(editionId);

            // Assert
            result.Should().BeNull();
            mock.Verify(x => x.ActivityRepository.GetAll(),
                Times.Once);
        }

    }
}
