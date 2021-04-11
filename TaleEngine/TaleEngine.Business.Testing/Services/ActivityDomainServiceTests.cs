using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Fakes.Dtos;
using TaleEngine.Fakes.Entities;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class ActivityDomainServiceTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<IActivityRepository> activityRepoMock;
        private Mock<IActivityStatusRepository> activityStatusRepoMock;

        public ActivityDomainServiceTests()
        {
            uowMock = new Mock<IUnitOfWork>();
            activityRepoMock = new Mock<IActivityRepository>();
            activityStatusRepoMock = new Mock<IActivityStatusRepository>();
        }

        [Fact]
        public void GetActiveActivities_Success()
        {
            // Arrange
            int editionId = 1;

            List<Activity> list = ActivityBuilder.BuildActivityList();
            var status = ActivityBuilder.BuildActivityStatus();

            activityRepoMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetActiveActivities(editionId);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetActiveActivities_IdIsZero_ShouldReturnNull()
        {
            // Arrange
            int editionId = 1;

            List<Activity> list = null;
            var status = ActivityBuilder.BuildActivityStatus();

            activityRepoMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetActiveActivities(editionId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetActiveActivities_StatusNotExist_ShouldReturnNull()
        {
            // Arrange
            int editionId = 1;

            List<Activity> list = null;
            ActivityStatus status = null;

            activityRepoMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetActiveActivities(editionId);

            // Assert
            result.Should().BeNull();
        }


        [Fact]
        public void GetPendingActivities_Success()
        {
            // Arrange
            int editionId = 1;

            List<Activity> list = ActivityBuilder.BuildActivityList();
            var status = ActivityBuilder.BuildActivityStatus();

            activityRepoMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetActiveActivities(editionId);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetPendingActivities_IdIsZero_ShouldReturnNull()
        {
            // Arrange
            int editionId = 1;

            List<Activity> list = null;
            var status = ActivityBuilder.BuildActivityStatus();

            activityRepoMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetActiveActivities(editionId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetPendingActivities_StatusNotExist_ShouldReturnNull()
        {
            // Arrange
            int editionId = 1;

            List<Activity> list = null;
            ActivityStatus status = null;

            activityRepoMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetActiveActivities(editionId);

            // Assert
            result.Should().BeNull();
        }


    }
}
