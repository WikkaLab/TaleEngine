using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.CQRS.Queries;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class ActivityQueriesTests
    {
        private readonly Mock<IActivityService> _activityServiceMock;
        private readonly Mock<IEditionService> _editionServiceMock;

        public ActivityQueriesTests()
        {
            _activityServiceMock = new Mock<IActivityService>();
            _editionServiceMock = new Mock<IEditionService>();
        }

        [Fact]
        public void ActiveActivitiesQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetActiveActivities(It.IsAny<int>())).Returns((List<ActivityEntity>)null);
            var target = BuildTarget();

            // Act
            var result = target.ActiveActivitiesQuery(2);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void ActiveActivitiesQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetActiveActivities(2)).Returns(new List<ActivityEntity>
            {
                new ActivityEntity { Id = 1, Title = "A", Description = "Desc", Places = 10, TypeId = 4, StatusId = 2, TimeSlotId = 3, LocationId = 7 }
            });
            var target = BuildTarget();

            // Act
            var result = target.ActiveActivitiesQuery(2);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(1);
            result[0].Title.Should().Be("A");
        }

        [Fact]
        public void PendingActivitiesQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetPendingActivities(It.IsAny<int>())).Returns((List<ActivityEntity>)null);
            var target = BuildTarget();

            // Act
            var result = target.PendingActivitiesQuery(2);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void PendingActivitiesQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetPendingActivities(2)).Returns(new List<ActivityEntity>
            {
                new ActivityEntity { Id = 9, Title = "Pending", Description = "Desc", Places = 6, TypeId = 1, StatusId = 1, TimeSlotId = 3, LocationId = 8 }
            });
            var target = BuildTarget();

            // Act
            var result = target.PendingActivitiesQuery(2);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(9);
            result[0].StatusId.Should().Be(1);
        }

        [Fact]
        public void ActiveActivitiesFilteredQuery_WhenEditionDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var request = new ActivityFilterRequest
            {
                EditionId = 5,
                Page = 0,
                TimeFrames = new List<int>(),
                Title = string.Empty
            };
            _editionServiceMock.Setup(x => x.GetById(request.EditionId)).Returns((EditionEntity)null);
            var target = BuildTarget();

            // Act
            var result = target.ActiveActivitiesFilteredQuery(request, userId: 3);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void ActiveActivitiesFilteredQuery_WhenServiceReturnsEmpty_ShouldReturnZeroPagesAndNullActivities()
        {
            // Arrange
            var request = new ActivityFilterRequest
            {
                EditionId = 5,
                Page = 0,
                TimeFrames = new List<int>(),
                Title = string.Empty
            };
            _editionServiceMock.Setup(x => x.GetById(request.EditionId)).Returns(new EditionEntity { Id = request.EditionId });
            _activityServiceMock.Setup(x => x.GetActiveActivitiesFiltered(request.TypeId, request.EditionId, request.TimeFrames, request.Title, 3))
                .Returns(new List<ActivityEntity>());
            var target = BuildTarget();

            // Act
            var result = target.ActiveActivitiesFilteredQuery(request, userId: 3);

            // Assert
            result.Should().NotBeNull();
            result.CurrentPage.Should().Be(0);
            result.TotalPages.Should().Be(0);
            result.Activities.Should().BeNull();
        }

        [Fact]
        public void LastThreeActivitiesQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetLastThreeActivities(It.IsAny<int>())).Returns((List<ActivityEntity>)null);
            var target = BuildTarget();

            // Act
            var result = target.LastThreeActivitiesQuery(3);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void LastThreeActivitiesQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetLastThreeActivities(3)).Returns(new List<ActivityEntity>
            {
                new ActivityEntity { Id = 20, Title = "Latest", Description = "Desc", Places = 12, TypeId = 2, StatusId = 2, TimeSlotId = 1 }
            });
            var target = BuildTarget();

            // Act
            var result = target.LastThreeActivitiesQuery(3);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(20);
        }

        [Fact]
        public void FavouriteActivitiesByUserQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetFavouriteActivitiesByUser(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((List<ActivityEntity>)null);
            var target = BuildTarget();

            // Act
            var result = target.FavouriteActivitiesByUserQuery(2, 3);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void FavouriteActivitiesByUserQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetFavouriteActivitiesByUser(2, 3)).Returns(new List<ActivityEntity>
            {
                new ActivityEntity { Id = 21, Title = "Favorite", Description = "Desc", Places = 15, TypeId = 3, StatusId = 2, TimeSlotId = 4 }
            });
            var target = BuildTarget();

            // Act
            var result = target.FavouriteActivitiesByUserQuery(2, 3);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(21);
        }

        [Fact]
        public void GetWaitingListQuery_WhenActivityDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns((ActivityEntity)null);
            var target = BuildTarget();

            // Act
            var result = target.GetWaitingListQuery(11);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetWaitingListQuery_WhenWaitingListIsNull_ShouldReturnZeroAndEmptyCollection()
        {
            // Arrange
            const int activityId = 11;
            _activityServiceMock.Setup(x => x.GetById(activityId)).Returns(new ActivityEntity { Id = activityId, Title = "Session" });
            _activityServiceMock.Setup(x => x.GetWaitingList(activityId)).Returns((List<UserEntity>)null);
            var target = BuildTarget();

            // Act
            var result = target.GetWaitingListQuery(activityId);

            // Assert
            result.Should().NotBeNull();
            result.ActivityId.Should().Be(activityId);
            result.ActivityTitle.Should().Be("Session");
            result.TotalWaiting.Should().Be(0);
            result.UsersInWaitingList.Should().NotBeNull();
            result.UsersInWaitingList.Should().BeEmpty();
        }

        [Fact]
        public void GetWaitingListQuery_WhenWaitingListHasUsers_ShouldMapUsersWithPositions()
        {
            // Arrange
            const int activityId = 11;
            _activityServiceMock.Setup(x => x.GetById(activityId)).Returns(new ActivityEntity { Id = activityId, Title = "Session" });
            _activityServiceMock.Setup(x => x.GetWaitingList(activityId)).Returns(new List<UserEntity>
            {
                new UserEntity { Id = 100, Username = "first" },
                new UserEntity { Id = 101, Username = "second" }
            });
            var target = BuildTarget();

            // Act
            var result = target.GetWaitingListQuery(activityId);

            // Assert
            result.Should().NotBeNull();
            result.TotalWaiting.Should().Be(2);
            result.UsersInWaitingList.Should().HaveCount(2);
            result.UsersInWaitingList[0].UserId.Should().Be(100);
            result.UsersInWaitingList[0].Position.Should().Be(1);
            result.UsersInWaitingList[1].UserId.Should().Be(101);
            result.UsersInWaitingList[1].Position.Should().Be(2);
        }

        [Fact]
        public void GetUserPositionInWaitingListQuery_WhenServiceReturnsPosition_ShouldReturnPosition()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetUserPositionInWaitingList(8, 9)).Returns(3);
            var target = BuildTarget();

            // Act
            var result = target.GetUserPositionInWaitingListQuery(8, 9);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void GetUserPositionInWaitingListQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _activityServiceMock.Setup(x => x.GetUserPositionInWaitingList(8, 9)).Returns((int?)null);
            var target = BuildTarget();

            // Act
            var result = target.GetUserPositionInWaitingListQuery(8, 9);

            // Assert
            result.Should().BeNull();
        }

        private ActivityQueries BuildTarget()
        {
            return new ActivityQueries(_activityServiceMock.Object, _editionServiceMock.Object);
        }
    }
}
