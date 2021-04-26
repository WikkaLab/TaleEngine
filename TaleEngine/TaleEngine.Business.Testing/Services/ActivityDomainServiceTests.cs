using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Business.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class ActivityDomainServiceTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<IActivityRepository> activityRepoMock;
        private Mock<IActivityStatusRepository> activityStatusRepoMock;
        private Mock<IEditionRepository> editionRepoMock;

        public ActivityDomainServiceTests()
        {
            uowMock = new Mock<IUnitOfWork>();
            activityRepoMock = new Mock<IActivityRepository>();
            activityStatusRepoMock = new Mock<IActivityStatusRepository>();
            editionRepoMock = new Mock<IEditionRepository>();
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
            var result = target.GetPendingActivities(editionId);

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
            var result = target.GetPendingActivities(editionId);

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
            var result = target.GetPendingActivities(editionId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetFilteredActiveActivities_Success()
        {
            // Arrange
            int typeId = 1;
            string title = "title";
            int currentPage = 1;

            int totalActivities = 40;

            List<Activity> list = ActivityBuilder.BuildActivityList();
            var status = ActivityBuilder.BuildActivityStatus();
            var edition = EditionBuilder.BuildEdition();

            activityRepoMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            activityRepoMock.Setup(x => x.GetTotalActivities(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>(), It.IsAny<string>()))
                .Returns(totalActivities);
            activityRepoMock.Setup(x => x.GetActiveActivitiesFiltered(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            editionRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);
            uowMock.Setup(x => x.EditionRepository)
                .Returns(editionRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetActiveActivitiesFiltered(typeId, edition.Id, title, currentPage);

            // Assert
            result.Should().NotBeNull();
            result.Activities.Should().NotBeEmpty();
        }

        [Fact]
        public void GetFilteredActiveActivities_EditionNotExist_ShouldReturnNull()
        {
            // Arrange
            int editionId = 0;
            int typeId = 1;
            string title = "title";
            int currentPage = 1;

            var status = ActivityBuilder.BuildActivityStatus();
            Edition edition = null;

            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            editionRepoMock.Setup(x => x.GetById(editionId))
                .Returns(edition);
            uowMock.Setup(x => x.EditionRepository)
                .Returns(editionRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetActiveActivitiesFiltered(typeId, editionId, title, currentPage);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetFilteredActiveActivities_StatusNotExist_ShouldReturnNull()
        {
            // Arrange
            int editionId = 1;
            int typeId = 1;
            string title = "title";
            int currentPage = 1;
            int statusId = 0;

            ActivityStatus status = null;
            Edition edition = EditionBuilder.BuildEdition();

            activityStatusRepoMock.Setup(x => x.GetById(statusId))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            editionRepoMock.Setup(x => x.GetById(editionId))
                .Returns(edition);
            uowMock.Setup(x => x.EditionRepository)
                .Returns(editionRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetActiveActivitiesFiltered(typeId, editionId, title, currentPage);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetLastThreeActivities_Success()
        {
            // Arrange
            List<Activity> list = ActivityBuilder.BuildActivityList();
            ActivityStatus status = ActivityBuilder.BuildActivityStatus();
            Edition edition = EditionBuilder.BuildEdition();

            activityRepoMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            editionRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);
            uowMock.Setup(x => x.EditionRepository)
                .Returns(editionRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetLastThreeActivities(edition.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetLastThreeActivities_EditionNotExist_ShouldReturnNull()
        {
            // Arrange
            int editionId = 0;
            List<Activity> list = ActivityBuilder.BuildActivityList();
            ActivityStatus status = ActivityBuilder.BuildActivityStatus();
            Edition edition = null;

            activityRepoMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            editionRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);
            uowMock.Setup(x => x.EditionRepository)
                .Returns(editionRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetLastThreeActivities(editionId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetLastThreeActivities_StatusNotExist_ShouldReturnNull()
        {
            // Arrange
            List<Activity> list = ActivityBuilder.BuildActivityList();
            ActivityStatus status = null;
            Edition edition = EditionBuilder.BuildEdition();

            activityRepoMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            editionRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);
            uowMock.Setup(x => x.EditionRepository)
                .Returns(editionRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetLastThreeActivities(edition.Id);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetLastThreeActivities_NoActivities_ShouldReturnNull()
        {
            // Arrange
            List<Activity> list = null;
            ActivityStatus status = ActivityBuilder.BuildActivityStatus();
            Edition edition = EditionBuilder.BuildEdition();

            activityRepoMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            editionRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);
            uowMock.Setup(x => x.EditionRepository)
                .Returns(editionRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetLastThreeActivities(edition.Id);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetLastThreeActivities_ActivitiesEmpty_ShouldReturnNull()
        {
            // Arrange
            List<Activity> list = new();
            ActivityStatus status = ActivityBuilder.BuildActivityStatus();
            Edition edition = EditionBuilder.BuildEdition();

            activityRepoMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            activityRepoMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(list);
            uowMock.Setup(x => x.ActivityRepository)
                .Returns(activityRepoMock.Object);
            activityStatusRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            editionRepoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);
            uowMock.Setup(x => x.EditionRepository)
                .Returns(editionRepoMock.Object);
            var target = new ActivityDomainService(uowMock.Object);

            // Act
            var result = target.GetLastThreeActivities(edition.Id);

            // Assert
            result.Should().BeNull();
        }

    }
}
