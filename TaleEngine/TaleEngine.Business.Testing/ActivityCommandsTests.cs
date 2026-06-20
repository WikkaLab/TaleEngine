using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.CQRS.Commands;
using TaleEngine.Cross.Enums;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class ActivityCommandsTests
    {
        private readonly Mock<IActivityService> _activityServiceMock;
        private readonly Mock<IActivityStatusService> _activityStatusServiceMock;
        private readonly Mock<IActivityTypeService> _activityTypeServiceMock;
        private readonly Mock<IEditionService> _editionServiceMock;
        private readonly Mock<ITimeSlotService> _timeSlotServiceMock;

        public ActivityCommandsTests()
        {
            _activityServiceMock = new Mock<IActivityService>();
            _activityStatusServiceMock = new Mock<IActivityStatusService>();
            _activityTypeServiceMock = new Mock<IActivityTypeService>();
            _editionServiceMock = new Mock<IEditionService>();
            _timeSlotServiceMock = new Mock<ITimeSlotService>();
        }

        [Fact]
        public void DeleteCommand_ShouldCallServiceWithSameId()
        {
            // Arrange
            const int activityId = 22;
            var target = BuildTarget();

            // Act
            target.DeleteCommand(activityId);

            // Assert
            _activityServiceMock.Verify(x => x.DeleteActivity(activityId), Times.Once);
        }

        [Fact]
        public void CreateCommand_ShouldMapDtoAndCallCreateActivity()
        {
            // Arrange
            const int editionId = 7;
            var dto = new ActivityDto
            {
                Title = "Intro to CQRS",
                Description = "Session",
                Places = 30,
                Image = "image.png",
                TypeId = 4,
                TimeSlotId = 8,
                LocationId = 11
            };

            _editionServiceMock
                .Setup(x => x.GetById(editionId))
                .Returns(new EditionEntity { Id = editionId });
            _activityTypeServiceMock
                .Setup(x => x.GetById(dto.TypeId))
                .Returns(new ActivityTypeEntity { Id = dto.TypeId });
            _timeSlotServiceMock
                .Setup(x => x.GetById(dto.TimeSlotId))
                .Returns(new TimeSlotEntity { Id = dto.TimeSlotId });
            _activityStatusServiceMock
                .Setup(x => x.GetById((int)ActivityStatusEnum.PEN))
                .Returns(new ActivityStatusEntity { Id = (int)ActivityStatusEnum.PEN });

            var target = BuildTarget();

            // Act
            target.CreateCommand(editionId, dto);

            // Assert
            _activityServiceMock.Verify(
                x => x.CreateActivity(
                    editionId,
                    It.Is<TaleEngine.Aggregates.ActivityAggregate.Activity>(a =>
                        a.Title == dto.Title
                        && a.Description == dto.Description
                        && a.Places == dto.Places
                        && a.Image == dto.Image
                        && a.Type == dto.TypeId
                        && a.TimeSlot == dto.TimeSlotId
                        && a.Location == dto.LocationId
                        && a.Status == (int)ActivityStatusEnum.PEN)),
                Times.Once);
        }

        [Fact]
        public void UpdateCommand_ShouldMapDtoAndCallUpdateActivity()
        {
            // Arrange
            var dto = new ActivityDto
            {
                Id = 55,
                Title = "Updated",
                Description = "Updated desc",
                Places = 50,
                Image = "updated.png",
                TimeSlotId = 3,
                LocationId = 9
            };

            _timeSlotServiceMock
                .Setup(x => x.GetById(dto.TimeSlotId))
                .Returns(new TimeSlotEntity { Id = dto.TimeSlotId });

            var target = BuildTarget();

            // Act
            target.UpdateCommand(dto);

            // Assert
            _activityServiceMock.Verify(
                x => x.UpdateActivity(
                    dto.Id,
                    It.Is<TaleEngine.Aggregates.ActivityAggregate.Activity>(a =>
                        a.Title == dto.Title
                        && a.Description == dto.Description
                        && a.Places == dto.Places
                        && a.Image == dto.Image
                        && a.TimeSlot == dto.TimeSlotId
                        && a.Location == dto.LocationId)),
                Times.Once);
        }

        [Fact]
        public void ChangeActivityStatusCommand_ShouldUpdateActivityStatus()
        {
            // Arrange
            const int activityId = 100;
            const int statusId = 2;

            _activityServiceMock
                .Setup(x => x.GetById(activityId))
                .Returns(new ActivityEntity
                {
                    Id = activityId,
                    Title = "Title",
                    Description = "Desc",
                    Places = 10,
                    Image = "image.png",
                    StatusId = 1,
                    TimeSlotId = 5,
                    TypeId = 6,
                    LocationId = 7
                });

            _activityStatusServiceMock
                .Setup(x => x.GetById(statusId))
                .Returns(new ActivityStatusEntity { Id = statusId });

            var target = BuildTarget();

            // Act
            target.ChangeActivityStatusCommand(activityId, statusId);

            // Assert
            _activityServiceMock.Verify(
                x => x.UpdateActivity(
                    activityId,
                    It.Is<TaleEngine.Aggregates.ActivityAggregate.Activity>(a => a.Status == statusId)),
                Times.Once);
        }

        [Fact]
        public void EnrollInActivityCommand_WhenActivityDoesNotExist_ShouldReturnFailure()
        {
            // Arrange
            var request = new ActivityEnrollmentRequest { ActivityId = 3, UserId = 9 };
            _activityServiceMock.Setup(x => x.GetById(request.ActivityId)).Returns((ActivityEntity)null);
            var target = BuildTarget();

            // Act
            var result = target.EnrollInActivityCommand(request);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Be("Activity not found");
        }

        [Fact]
        public void EnrollInActivityCommand_WhenEnrollmentFails_ShouldReturnFailure()
        {
            // Arrange
            var request = new ActivityEnrollmentRequest { ActivityId = 3, UserId = 9 };
            _activityServiceMock.Setup(x => x.GetById(request.ActivityId))
                .Returns(new ActivityEntity { Id = request.ActivityId, Places = 10 });
            _activityServiceMock.Setup(x => x.EnrollUserInActivity(request.ActivityId, request.UserId)).Returns(false);

            var target = BuildTarget();

            // Act
            var result = target.EnrollInActivityCommand(request);

            // Assert
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Enrollment failed");
        }

        [Fact]
        public void EnrollInActivityCommand_WhenEnrollmentSucceedsWithoutWaitingList_ShouldReturnSuccess()
        {
            // Arrange
            var request = new ActivityEnrollmentRequest { ActivityId = 3, UserId = 9 };

            _activityServiceMock.SetupSequence(x => x.GetById(request.ActivityId))
                .Returns(new ActivityEntity { Id = request.ActivityId, Places = 5 })
                .Returns(new ActivityEntity
                {
                    Id = request.ActivityId,
                    Places = 5,
                    UsersPlay = new List<UserEntity>
                    {
                        new UserEntity { Id = 1 },
                        new UserEntity { Id = 2 }
                    }
                });
            _activityServiceMock.Setup(x => x.EnrollUserInActivity(request.ActivityId, request.UserId)).Returns(true);

            var target = BuildTarget();

            // Act
            var result = target.EnrollInActivityCommand(request);

            // Assert
            result.Success.Should().BeTrue();
            result.IsWaitingList.Should().BeFalse();
            result.AvailablePlaces.Should().Be(3);
            result.Message.Should().Be("Successfully enrolled in activity");
            _activityServiceMock.Verify(x => x.GetUserPositionInWaitingList(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void EnrollInActivityCommand_WhenEnrollmentSucceedsAndIsWaitingList_ShouldReturnWaitingListInfo()
        {
            // Arrange
            var request = new ActivityEnrollmentRequest { ActivityId = 3, UserId = 9 };

            _activityServiceMock.SetupSequence(x => x.GetById(request.ActivityId))
                .Returns(new ActivityEntity { Id = request.ActivityId, Places = 2 })
                .Returns(new ActivityEntity
                {
                    Id = request.ActivityId,
                    Places = 2,
                    UsersPlay = new List<UserEntity>
                    {
                        new UserEntity { Id = 1 },
                        new UserEntity { Id = 2 }
                    }
                });
            _activityServiceMock.Setup(x => x.EnrollUserInActivity(request.ActivityId, request.UserId)).Returns(true);
            _activityServiceMock.Setup(x => x.GetUserPositionInWaitingList(request.ActivityId, request.UserId)).Returns(4);

            var target = BuildTarget();

            // Act
            var result = target.EnrollInActivityCommand(request);

            // Assert
            result.Success.Should().BeTrue();
            result.IsWaitingList.Should().BeTrue();
            result.PositionInWaitingList.Should().Be(4);
            result.Message.Should().Contain("position 4");
            _activityServiceMock.Verify(x => x.GetUserPositionInWaitingList(request.ActivityId, request.UserId), Times.Once);
        }

        [Fact]
        public void LeaveActivityCommand_ShouldReturnServiceResult()
        {
            // Arrange
            var request = new ActivityEnrollmentRequest { ActivityId = 1, UserId = 2 };
            _activityServiceMock.Setup(x => x.RemoveUserFromActivity(request.ActivityId, request.UserId)).Returns(true);
            var target = BuildTarget();

            // Act
            var result = target.LeaveActivityCommand(request);

            // Assert
            result.Should().BeTrue();
            _activityServiceMock.Verify(x => x.RemoveUserFromActivity(request.ActivityId, request.UserId), Times.Once);
        }

        [Fact]
        public void AddFavouriteActivityCommand_ShouldReturnServiceResult()
        {
            // Arrange
            var request = new ActivityEnrollmentRequest { ActivityId = 1, UserId = 2 };
            _activityServiceMock.Setup(x => x.AddFavouriteActivity(request.ActivityId, request.UserId)).Returns(true);
            var target = BuildTarget();

            // Act
            var result = target.AddFavouriteActivityCommand(request);

            // Assert
            result.Should().BeTrue();
            _activityServiceMock.Verify(x => x.AddFavouriteActivity(request.ActivityId, request.UserId), Times.Once);
        }

        [Fact]
        public void RemoveFavouriteActivityCommand_ShouldReturnServiceResult()
        {
            // Arrange
            var request = new ActivityEnrollmentRequest { ActivityId = 1, UserId = 2 };
            _activityServiceMock.Setup(x => x.RemoveFavouriteActivity(request.ActivityId, request.UserId)).Returns(true);
            var target = BuildTarget();

            // Act
            var result = target.RemoveFavouriteActivityCommand(request);

            // Assert
            result.Should().BeTrue();
            _activityServiceMock.Verify(x => x.RemoveFavouriteActivity(request.ActivityId, request.UserId), Times.Once);
        }

        private ActivityCommands BuildTarget()
        {
            return new ActivityCommands(
                _activityServiceMock.Object,
                _activityStatusServiceMock.Object,
                _activityTypeServiceMock.Object,
                _timeSlotServiceMock.Object,
                _editionServiceMock.Object);
        }
    }
}
