using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Fakes.Dtos;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class ActivityServiceTests
    {
        private Mock<IActivityDomainService> serviceMock;

        public ActivityServiceTests()
        {
            serviceMock = new Mock<IActivityDomainService>();
        }

        [Fact]
        public void GetActiveActivities_Success()
        {
            // Arrange
            int editionId = 1;
            serviceMock.Setup(x => x.GetActiveActivities(editionId))
                .Returns(ActivityModelBuilder.BuildActivityModelList());

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.GetActiveActivities(editionId);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            serviceMock.Verify(x => x.GetActiveActivities(It.IsAny<int>()),
                Times.Once);
        }

        [Fact]
        public void GetActiveActivities_IdIsZero_ShouldReturnNull()
        {
            // Arrange
            int editionId = 0;
            List<ActivityModel> models = null;
            serviceMock.Setup(x => x.GetActiveActivities(editionId))
                .Returns(models);

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.GetActiveActivities(editionId);

            // Assert
            result.Should().BeNull();
            serviceMock.Verify(x => x.GetActiveActivities(It.IsAny<int>()),
                Times.Once);
        }

        [Fact]
        public void GetPendingActivities_Success()
        {
            // Arrange
            int editionId = 1;
            serviceMock.Setup(x => x.GetPendingActivities(editionId))
                .Returns(ActivityModelBuilder.BuildActivityModelList());

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.GetPendingActivities(editionId);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            serviceMock.Verify(x => x.GetPendingActivities(It.IsAny<int>()),
                Times.Once);
        }

        [Fact]
        public void GetPendingActivities_IdIsZero_ShouldReturnNull()
        {
            // Arrange
            int editionId = 0;
            List<ActivityModel> models = null;
            serviceMock.Setup(x => x.GetPendingActivities(editionId))
                .Returns(models);

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.GetPendingActivities(editionId);

            // Assert
            result.Should().BeNull();
            serviceMock.Verify(x => x.GetPendingActivities(It.IsAny<int>()),
                Times.Once);
        }

        [Fact]
        public void DeleteActivity_Success()
        {
            // Arrange
            int activityId = 1;

            serviceMock.Setup(x => x.DeleteActivity(activityId))
                .Returns(0);

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.DeleteActivity(activityId);

            // Assert
            result.Should().Be(0);
            serviceMock.Verify(x => x.DeleteActivity(It.IsAny<int>()),
                Times.Once);
        }

        [Fact]
        public void CreateActivity_Success()
        {
            // Arrange
            int editionId = 1;
            var activityDto = ActivityDtoBuilder.BuildActivityDto();

            serviceMock.Setup(x => x.CreateActivity(editionId, It.IsAny<ActivityModel>()))
                .Returns(1);

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.CreateActivity(editionId, activityDto);

            // Assert
            result.Should().Be(1);
            serviceMock.Verify(x => x.CreateActivity(editionId, It.IsAny<ActivityModel>()),
                Times.Once);
        }

        [Fact]
        public void CreateActivity_DtoIsNull_ShouldReturnZero()
        {
            // Arrange
            int editionId = 1;
            ActivityDto activityDto = null;

            serviceMock.Setup(x => x.CreateActivity(editionId, It.IsAny<ActivityModel>()))
                .Returns(0);

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.CreateActivity(editionId, activityDto);

            // Assert
            result.Should().Be(0);
            serviceMock.Verify(x => x.CreateActivity(editionId, It.IsAny<ActivityModel>()),
                Times.Once);
        }

        [Fact]
        public void UpdateActivity_Success()
        {
            // Arrange
            var activityDto = ActivityDtoBuilder.BuildActivityDto();

            serviceMock.Setup(x => x.UpdateActivity(It.IsAny<ActivityModel>()))
                .Returns(1);

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.UpdateActivity(activityDto);

            // Assert
            result.Should().Be(1);
            serviceMock.Verify(x => x.UpdateActivity(It.IsAny<ActivityModel>()),
                Times.Once);
        }

        [Fact]
        public void UpdateActivity_DtoIsNull_ShouldReturnZero()
        {
            // Arrange
            ActivityDto activityDto = null;

            serviceMock.Setup(x => x.UpdateActivity(It.IsAny<ActivityModel>()))
                .Returns(0);

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.UpdateActivity(activityDto);

            // Assert
            result.Should().Be(0);
            serviceMock.Verify(x => x.UpdateActivity(It.IsAny<ActivityModel>()),
                Times.Once);
        }

        [Fact]
        public void GetActiveActivitiesFiltered_Success()
        {
            // Arrange
            var request = ActivityDtoBuilder.BuildActivityFilterRequest();
            var resultModel = ActivityModelBuilder.BuildActivityFilteredResultModel();

            serviceMock.Setup(x => x.GetActiveActivitiesFiltered(request.TypeId,
                request.EditionId, request.Title, request.CurrentPage))
                .Returns(resultModel);

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.GetActiveActivitiesFiltered(request);

            // Assert
            result.Should().NotBeNull();
            result.Activities.Should().NotBeNull();
            result.Activities.Should().NotBeEmpty();
            serviceMock.Verify(x => x.GetActiveActivitiesFiltered(It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()),
                Times.Once);
        }

        [Fact]
        public void ChangeActivityStatus_Success()
        {
            // Arrange
            var activityDto = ActivityDtoBuilder.BuildActivityChangeStatusDto();

            serviceMock.Setup(x => x.ChangeActivityStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(1);

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.ChangeActivityStatus(activityDto);

            // Assert
            result.Should().Be(1);
            serviceMock.Verify(x => x.ChangeActivityStatus(It.IsAny<int>(), It.IsAny<int>()),
                Times.Once);
        }

        [Fact]
        public void GetLastThreeActivities_Success()
        {
            // Arrange
            int editionId = 1;
            serviceMock.Setup(x => x.GetLastThreeActivities(editionId))
                .Returns(ActivityModelBuilder.BuildActivityModelList());

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.GetLastThreeActivities(editionId);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            serviceMock.Verify(x => x.GetLastThreeActivities(It.IsAny<int>()),
                Times.Once);
        }

        [Fact]
        public void GetLastThreeActivities_IdIsZero_ShouldReturnNull()
        {
            // Arrange
            int editionId = 0;
            List<ActivityModel> models = null;
            serviceMock.Setup(x => x.GetLastThreeActivities(editionId))
                .Returns(models);

            var target = new ActivityService(serviceMock.Object);

            // Act
            var result = target.GetLastThreeActivities(editionId);

            // Assert
            result.Should().BeNull();
            serviceMock.Verify(x => x.GetLastThreeActivities(It.IsAny<int>()),
                Times.Once);
        }

    }
}
