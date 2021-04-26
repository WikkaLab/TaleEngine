using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Business.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class ActivityDomainServiceTests
    {
        private readonly Mock<IActivityRepository> _activityRepositoryMock;
        private readonly Mock<IActivityStatusRepository> _activityStatusRepositoryMock;
        private readonly Mock<IEditionRepository> _editionRepositoryMock;
        private readonly Mock<IActivityTypeRepository> _activityTypeRepositoryMock;
        private readonly Mock<ITimeSlotRepository> _timeSlotRepositoryMock;

        public ActivityDomainServiceTests()
        {
            _activityRepositoryMock = new Mock<IActivityRepository>();
            _activityStatusRepositoryMock = new Mock<IActivityStatusRepository>();
            _activityTypeRepositoryMock = new Mock<IActivityTypeRepository>();
            _editionRepositoryMock = new Mock<IEditionRepository>();
            _timeSlotRepositoryMock = new Mock<ITimeSlotRepository>();
        }

        private ActivityDomainService CreateActivityDomainService()
        {
            return new ActivityDomainService(
                _activityRepositoryMock.Object,
                _activityStatusRepositoryMock.Object,
                _activityTypeRepositoryMock.Object,
                _editionRepositoryMock.Object,
                _timeSlotRepositoryMock.Object);
        }

        [Fact]
        public void GetActiveActivities_Success()
        {
            // Arrange
            int editionId = 1;

            List<Activity> list = ActivityBuilder.BuildActivityList();
            var status = ActivityBuilder.BuildActivityStatus();

            _activityRepositoryMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityRepositoryMock.Setup(x => x.GetTotalActivities(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>(), It.IsAny<string>()))
                .Returns(totalActivities);
            _activityRepositoryMock.Setup(x => x.GetActiveActivitiesFiltered(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            _editionRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);

            var target = CreateActivityDomainService();

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

            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            _editionRepositoryMock.Setup(x => x.GetById(editionId))
                .Returns(edition);

            var target = CreateActivityDomainService();

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

            _activityStatusRepositoryMock.Setup(x => x.GetById(statusId))
                .Returns(status);
            _editionRepositoryMock.Setup(x => x.GetById(editionId))
                .Returns(edition);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            _editionRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            _editionRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            _editionRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            _editionRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);

            var target = CreateActivityDomainService();

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

            _activityRepositoryMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityRepositoryMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);
            _activityStatusRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(status);
            _editionRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(edition);

            var target = CreateActivityDomainService();

            // Act
            var result = target.GetLastThreeActivities(edition.Id);

            // Assert
            result.Should().BeNull();
        }
    }
}