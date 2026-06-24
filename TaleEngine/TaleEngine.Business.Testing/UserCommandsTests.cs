using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Commands.Backoffice;
using TaleEngine.CQRS.Contracts;
using TaleEngine.Cross.Enums;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class UserCommandsTests
    {
        private readonly Mock<IUserStatusQueries> _userStatusQueriesMock;
        private readonly Mock<IUserService> _userServiceMock;

        public UserCommandsTests()
        {
            _userStatusQueriesMock = new Mock<IUserStatusQueries>();
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public void RegisterCommand_WhenDtoIsNull_ShouldReturnNull()
        {
            // Arrange
            var target = BuildTarget();

            // Act
            var result = target.RegisterCommand(null);

            // Assert
            result.Should().BeNull();
            _userServiceMock.Verify(x => x.Register(It.IsAny<TaleEngine.Aggregates.UserAggregate.User>()), Times.Never);
        }

        [Fact]
        public void RegisterCommand_WhenUsernameOrMailIsInvalid_ShouldReturnNull()
        {
            // Arrange
            var target = BuildTarget();

            // Act
            var resultWithoutUsername = target.RegisterCommand(new UserDto { Username = "", Mail = "mail@site.com" });
            var resultWithoutMail = target.RegisterCommand(new UserDto { Username = "user", Mail = "  " });

            // Assert
            resultWithoutUsername.Should().BeNull();
            resultWithoutMail.Should().BeNull();
            _userServiceMock.Verify(x => x.Register(It.IsAny<TaleEngine.Aggregates.UserAggregate.User>()), Times.Never);
        }

        [Fact]
        public void RegisterCommand_WhenInputIsValid_ShouldMapAndReturnCreatedUser()
        {
            // Arrange
            var dto = new UserDto
            {
                Username = "john",
                Name = "John",
                Mail = "john@site.com",
                Website = "https://site.com",
                Blog = "https://blog.site.com"
            };

            _userServiceMock
                .Setup(x => x.Register(It.IsAny<TaleEngine.Aggregates.UserAggregate.User>()))
                .Returns(new UserEntity
                {
                    Username = dto.Username,
                    Name = dto.Name,
                    Mail = dto.Mail,
                    Website = dto.Website,
                    Blog = dto.Blog,
                    StatusId = (int)UserStatusEnum.PENDING
                });

            var target = BuildTarget();

            // Act
            var result = target.RegisterCommand(dto);

            // Assert
            result.Should().NotBeNull();
            result.Username.Should().Be(dto.Username);
            result.Mail.Should().Be(dto.Mail);
            _userServiceMock.Verify(
                x => x.Register(It.Is<TaleEngine.Aggregates.UserAggregate.User>(u =>
                    u.Username == dto.Username
                    && u.Name == dto.Name
                    && u.Mail == dto.Mail
                    && u.Website == dto.Website
                    && u.Blog == dto.Blog
                    && u.Status == (int)UserStatusEnum.PENDING)),
                Times.Once);
        }

        [Fact]
        public void UpdateProfileCommand_WhenInputIsInvalid_ShouldNotCallService()
        {
            // Arrange
            var target = BuildTarget();

            // Act
            target.UpdateProfileCommand(0, new UserDto());
            target.UpdateProfileCommand(1, null);

            // Assert
            _userServiceMock.Verify(x => x.UpdateProfile(It.IsAny<int>(), It.IsAny<TaleEngine.Aggregates.UserAggregate.User>()), Times.Never);
        }

        [Fact]
        public void UpdateProfileCommand_WhenUserDoesNotExist_ShouldNotUpdate()
        {
            // Arrange
            const int userId = 21;
            _userServiceMock.Setup(x => x.GetById(userId)).Returns((UserEntity)null);
            var target = BuildTarget();

            // Act
            target.UpdateProfileCommand(userId, new UserDto { Name = "New" });

            // Assert
            _userServiceMock.Verify(x => x.UpdateProfile(It.IsAny<int>(), It.IsAny<TaleEngine.Aggregates.UserAggregate.User>()), Times.Never);
        }

        [Fact]
        public void UpdateProfileCommand_WhenUserExists_ShouldPreserveUsernameAndStatus()
        {
            // Arrange
            const int userId = 21;
            var currentUser = new UserEntity
            {
                Id = userId,
                Username = "oldUser",
                StatusId = (int)UserStatusEnum.ACTIVE
            };
            var dto = new UserDto
            {
                Name = "New Name",
                Mail = "new@mail.com",
                Website = "https://newsite.com",
                Blog = "https://newblog.com"
            };

            _userServiceMock.Setup(x => x.GetById(userId)).Returns(currentUser);
            var target = BuildTarget();

            // Act
            target.UpdateProfileCommand(userId, dto);

            // Assert
            _userServiceMock.Verify(
                x => x.UpdateProfile(userId, It.Is<TaleEngine.Aggregates.UserAggregate.User>(u =>
                    u.Username == currentUser.Username
                    && u.Status == currentUser.StatusId
                    && u.Name == dto.Name
                    && u.Mail == dto.Mail
                    && u.Website == dto.Website
                    && u.Blog == dto.Blog)),
                Times.Once);
        }

        [Fact]
        public void ActivateCommand_WhenUserIdIsZero_ShouldNotChangeStatus()
        {
            // Arrange
            var target = BuildTarget();

            // Act
            target.ActivateCommand(0);

            // Assert
            _userStatusQueriesMock.Verify(x => x.ActiveQuery(), Times.Never);
            _userServiceMock.Verify(x => x.ChangeUserStatus(It.IsAny<int>(), It.IsAny<TaleEngine.Aggregates.UserAggregate.User>()), Times.Never);
        }

        [Fact]
        public void ActivateCommand_WhenStatusNotFound_ShouldNotChangeStatus()
        {
            // Arrange
            const int userId = 5;
            _userStatusQueriesMock.Setup(x => x.ActiveQuery()).Returns(0);
            var target = BuildTarget();

            // Act
            target.ActivateCommand(userId);

            // Assert
            _userServiceMock.Verify(x => x.ChangeUserStatus(It.IsAny<int>(), It.IsAny<TaleEngine.Aggregates.UserAggregate.User>()), Times.Never);
        }

        [Fact]
        public void ActivateCommand_WhenUserExists_ShouldChangeStatusToActive()
        {
            // Arrange
            const int userId = 5;
            const int activeStatusId = (int)UserStatusEnum.ACTIVE;

            _userStatusQueriesMock.Setup(x => x.ActiveQuery()).Returns(activeStatusId);
            _userServiceMock.Setup(x => x.GetById(userId)).Returns(new UserEntity { Id = userId, StatusId = 1 });

            var target = BuildTarget();

            // Act
            target.ActivateCommand(userId);

            // Assert
            _userServiceMock.Verify(
                x => x.ChangeUserStatus(userId, It.Is<TaleEngine.Aggregates.UserAggregate.User>(u => u.Status == activeStatusId)),
                Times.Once);
        }

        [Fact]
        public void BanCommand_ShouldUseBanStatusAndChangeStatus()
        {
            // Arrange
            const int userId = 6;
            const int banStatusId = (int)UserStatusEnum.BANNED;

            _userStatusQueriesMock.Setup(x => x.BanQuery()).Returns(banStatusId);
            _userServiceMock.Setup(x => x.GetById(userId)).Returns(new UserEntity { Id = userId });
            var target = BuildTarget();

            // Act
            target.BanCommand(userId);

            // Assert
            _userServiceMock.Verify(
                x => x.ChangeUserStatus(userId, It.Is<TaleEngine.Aggregates.UserAggregate.User>(u => u.Status == banStatusId)),
                Times.Once);
        }

        [Fact]
        public void DeactivateCommand_ShouldUseInactiveStatusAndChangeStatus()
        {
            // Arrange
            const int userId = 7;
            const int inactiveStatusId = (int)UserStatusEnum.INACTIVE;

            _userStatusQueriesMock.Setup(x => x.InactiveQuery()).Returns(inactiveStatusId);
            _userServiceMock.Setup(x => x.GetById(userId)).Returns(new UserEntity { Id = userId });
            var target = BuildTarget();

            // Act
            target.DeactivateCommand(userId);

            // Assert
            _userServiceMock.Verify(
                x => x.ChangeUserStatus(userId, It.Is<TaleEngine.Aggregates.UserAggregate.User>(u => u.Status == inactiveStatusId)),
                Times.Once);
        }

        [Fact]
        public void MarkAsPendingCommand_ShouldUsePendingStatusAndChangeStatus()
        {
            // Arrange
            const int userId = 8;
            const int pendingStatusId = (int)UserStatusEnum.PENDING;

            _userStatusQueriesMock.Setup(x => x.PendingQuery()).Returns(pendingStatusId);
            _userServiceMock.Setup(x => x.GetById(userId)).Returns(new UserEntity { Id = userId });
            var target = BuildTarget();

            // Act
            target.MarkAsPendingCommand(userId);

            // Assert
            _userServiceMock.Verify(
                x => x.ChangeUserStatus(userId, It.Is<TaleEngine.Aggregates.UserAggregate.User>(u => u.Status == pendingStatusId)),
                Times.Once);
        }

        [Fact]
        public void ReviewCommand_ShouldUseRevisionStatusAndChangeStatus()
        {
            // Arrange
            const int userId = 9;
            const int revisionStatusId = (int)UserStatusEnum.REVISION;

            _userStatusQueriesMock.Setup(x => x.RevisionQuery()).Returns(revisionStatusId);
            _userServiceMock.Setup(x => x.GetById(userId)).Returns(new UserEntity { Id = userId });
            var target = BuildTarget();

            // Act
            target.ReviewCommand(userId);

            // Assert
            _userServiceMock.Verify(
                x => x.ChangeUserStatus(userId, It.Is<TaleEngine.Aggregates.UserAggregate.User>(u => u.Status == revisionStatusId)),
                Times.Once);
        }

        [Fact]
        public void AssignRoleCommand_WhenIdsAreInvalid_ShouldNotCallService()
        {
            // Arrange
            var target = BuildTarget();

            // Act
            target.AssignRoleCommand(0, 1);
            target.AssignRoleCommand(1, 0);

            // Assert
            _userServiceMock.Verify(x => x.AssignRoleToUser(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void AssignRoleCommand_WhenIdsAreValid_ShouldCallService()
        {
            // Arrange
            const int userId = 3;
            const int roleId = 10;
            var target = BuildTarget();

            // Act
            target.AssignRoleCommand(userId, roleId);

            // Assert
            _userServiceMock.Verify(x => x.AssignRoleToUser(userId, roleId), Times.Once);
        }

        private UserCommands BuildTarget()
        {
            return new UserCommands(_userStatusQueriesMock.Object, _userServiceMock.Object);
        }
    }
}
