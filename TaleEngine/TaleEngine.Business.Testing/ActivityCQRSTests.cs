using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.CQRS.Queries;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class ActivityCQRSTests
    {
        private Mock<IActivityService> activityServMock;
        private Mock<IActivityStatusService> activityStatusServMock;
        private Mock<IActivityTypeService> activityTypesServMock;
        private Mock<IEditionService> editionServMock;
        private Mock<ITimeSlotService> timeSlotServMock;

        public ActivityCQRSTests()
        {
            activityServMock = new Mock<IActivityService>();
            activityStatusServMock = new Mock<IActivityStatusService>();
            timeSlotServMock = new Mock<ITimeSlotService>();
            editionServMock = new Mock<IEditionService>();
            activityTypesServMock = new Mock<IActivityTypeService>();
        }

        [Fact]
        public void GetActiveActivities_Success()
        {
            // Arrange
            int editionId = 1;

            List<ActivityEntity> list = ActivityBuilder.BuildActivityList();
            var status = ActivityBuilder.BuildActivityStatus();

            activityServMock.Setup(x => x.GetActiveActivities(It.IsAny<int>()))
                .Returns(list);

            var target = new ActivityQueries(activityServMock.Object);

            // Act
            var result = target.ActiveActivitiesQuery(editionId);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetActiveActivities_IdIsZero_ShouldReturnNull()
        {
            // Arrange
            int editionId = 0;

            List<ActivityEntity> list = null;
            var status = ActivityBuilder.BuildActivityStatus();

            activityServMock.Setup(x => x.GetActiveActivities(It.IsAny<int>()))
                .Returns(list);

            var target = new ActivityQueries(activityServMock.Object);

            // Act
            var result = target.ActiveActivitiesQuery(editionId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetActiveActivities_StatusNotExist_ShouldReturnNull()
        {
            // Arrange
            int editionId = 1;

            List<ActivityEntity> list = null;
            ActivityStatusEntity status = null;

            activityServMock.Setup(x => x.GetActiveActivities(It.IsAny<int>()))
                .Returns(list);

            var target = new ActivityQueries(activityServMock.Object);

            // Act
            var result = target.ActiveActivitiesQuery(editionId);

            // Assert
            result.Should().BeNull();
        }


        //[Fact]
        //public void GetPendingActivities_Success()
        //{
        //    // Arrange
        //    int editionId = 1;

        //    List<ActivityEntity> list = ActivityBuilder.BuildActivityList();
        //    var status = ActivityBuilder.BuildActivityStatus();

        //    activityServMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
        //        .Returns(list);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.PendingActivitiesQuery(editionId);

        //    // Assert
        //    result.Should().NotBeNull();
        //    result.Should().NotBeEmpty();
        //}

        //[Fact]
        //public void GetPendingActivities_IdIsZero_ShouldReturnNull()
        //{
        //    // Arrange
        //    int editionId = 1;

        //    List<ActivityEntity> list = null;
        //    var status = ActivityBuilder.BuildActivityStatus();

        //    activityServMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
        //        .Returns(list);
        //    activityStatusServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(status);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.PendingActivitiesQuery(editionId);

        //    // Assert
        //    result.Should().BeNull();
        //}

        //[Fact]
        //public void GetPendingActivities_StatusNotExist_ShouldReturnNull()
        //{
        //    // Arrange
        //    int editionId = 1;

        //    List<ActivityEntity> list = null;
        //    ActivityStatusEntity status = null;

        //    activityServMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
        //        .Returns(list);
        //    activityStatusServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(status);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.PendingActivitiesQuery(editionId);

        //    // Assert
        //    result.Should().BeNull();
        //}

        //[Fact]
        //public void GetFilteredActiveActivities_Success()
        //{
        //    // Arrange
        //    int typeId = 1;
        //    string title = "title";
        //    int currentPage = 1;

        //    int totalActivities = 40;

        //    List<ActivityEntity> list = ActivityBuilder.BuildActivityList();
        //    var status = ActivityBuilder.BuildActivityStatus();
        //    var edition = EditionBuilder.BuildEdition();

        //    activityServMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
        //        .Returns(list);
        //    activityServMock.Setup(x => x.GetTo(It.IsAny<int>(), It.IsAny<int>(),
        //            It.IsAny<int>(), It.IsAny<string>()))
        //        .Returns(totalActivities);
        //    activityServMock.Setup(x => x.GetActiveActivitiesFiltered(It.IsAny<int>(), It.IsAny<int>(),
        //            It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
        //        .Returns(list);
        //    activityStatusServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(status);
        //    timeSlotServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(edition);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.ActiveActivitiesFilteredQuery(typeId, edition.Id, title, currentPage);

        //    // Assert
        //    result.Should().NotBeNull();
        //    result.Activities.Should().NotBeEmpty();
        //}

        //[Fact]
        //public void GetFilteredActiveActivities_EditionNotExist_ShouldReturnNull()
        //{
        //    // Arrange
        //    int editionId = 0;
        //    int typeId = 1;
        //    string title = "title";
        //    int currentPage = 1;

        //    var status = ActivityBuilder.BuildActivityStatus();
        //    EditionEntity edition = null;

        //    activityStatusServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(status);
        //    timeSlotServMock.Setup(x => x.GetById(editionId))
        //        .Returns(edition);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.ActiveActivitiesFilteredQuery(typeId, editionId, title, currentPage);

        //    // Assert
        //    result.Should().BeNull();
        //}

        //[Fact]
        //public void GetFilteredActiveActivities_StatusNotExist_ShouldReturnNull()
        //{
        //    // Arrange
        //    int editionId = 1;
        //    int typeId = 1;
        //    string title = "title";
        //    int currentPage = 1;
        //    int statusId = 0;

        //    ActivityStatusEntity status = null;
        //    EditionEntity edition = EditionBuilder.BuildEdition();

        //    activityStatusServMock.Setup(x => x.GetById(statusId))
        //        .Returns(status);
        //    timeSlotServMock.Setup(x => x.GetById(editionId))
        //        .Returns(edition);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.ActiveActivitiesFilteredQuery(typeId, editionId, title, currentPage);

        //    // Assert
        //    result.Should().BeNull();
        //}

        //[Fact]
        //public void GetLastThreeActivities_Success()
        //{
        //    // Arrange
        //    List<ActivityEntity> list = ActivityBuilder.BuildActivityList();
        //    ActivityStatusEntity status = ActivityBuilder.BuildActivityStatus();
        //    EditionEntity edition = EditionBuilder.BuildEdition();

        //    activityServMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(),
        //            It.IsAny<int>()))
        //        .Returns(list);
        //    activityStatusServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(status);
        //    timeSlotServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(edition);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.LastThreeActivitiesQuery(edition.Id);

        //    // Assert
        //    result.Should().NotBeNull();
        //    result.Should().NotBeEmpty();
        //}

        //[Fact]
        //public void GetLastThreeActivities_EditionNotExist_ShouldReturnNull()
        //{
        //    // Arrange
        //    int editionId = 0;
        //    List<ActivityEntity> list = ActivityBuilder.BuildActivityList();
        //    ActivityStatusEntity status = ActivityBuilder.BuildActivityStatus();
        //    EditionEntity edition = null;

        //    activityServMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(),
        //            It.IsAny<int>()))
        //        .Returns(list);
        //    activityStatusServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(status);
        //    timeSlotServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(edition);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.LastThreeActivitiesQuery(editionId);

        //    // Assert
        //    result.Should().BeNull();
        //}

        //[Fact]
        //public void GetLastThreeActivities_StatusNotExist_ShouldReturnNull()
        //{
        //    // Arrange
        //    List<ActivityEntity> list = ActivityBuilder.BuildActivityList();
        //    ActivityStatusEntity status = null;
        //    EditionEntity edition = EditionBuilder.BuildEdition();

        //    activityServMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(),
        //            It.IsAny<int>()))
        //        .Returns(list);
        //    activityStatusServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(status);
        //    timeSlotServMock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(edition);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.LastThreeActivitiesQuery(edition.Id);

        //    // Assert
        //    result.Should().BeNull();
        //}

        //[Fact]
        //public void GetLastThreeActivities_NoActivities_ShouldReturnNull()
        //{
        //    // Arrange
        //    List<ActivityEntity> list = null;
        //    ActivityStatusEntity status = ActivityBuilder.BuildActivityStatus();
        //    EditionEntity edition = EditionBuilder.BuildEdition();

        //    activityServMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(),
        //            It.IsAny<int>()))
        //        .Returns(list);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.LastThreeActivitiesQuery(edition.Id);

        //    // Assert
        //    result.Should().BeNull();
        //}

        //[Fact]
        //public void GetLastThreeActivities_ActivitiesEmpty_ShouldReturnNull()
        //{
        //    // Arrange
        //    List<ActivityEntity> list = new();
        //    ActivityStatusEntity status = ActivityBuilder.BuildActivityStatus();
        //    EditionEntity edition = EditionBuilder.BuildEdition();

        //    activityServMock.Setup(x => x.GetActivitiesByStatus(It.IsAny<int>(), It.IsAny<int>()))
        //        .Returns(list);
        //    activityServMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>(), It.IsAny<int>(),
        //            It.IsAny<int>()))
        //        .Returns(list);

        //    var target = new ActivityCommands(activityServMock.Object, activityStatusServMock.Object,
        //       activityTypesServMock.Object, timeSlotServMock.Object,
        //       editionServMock.Object);

        //    // Act
        //    var result = target.LastThreeActivitiesQuery(edition.Id);

        //    // Assert
        //    result.Should().BeNull();
        //}

    }
}
