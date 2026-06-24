using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using TaleEngine.CQRS.Queries.Backoffice;
using TaleEngine.Cross.Enums;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class UserStatusQueriesTests
    {
        private readonly Mock<IUserStatusService> _serviceMock;

        public UserStatusQueriesTests()
        {
            _serviceMock = new Mock<IUserStatusService>();
        }

        [Fact]
        public void ActiveQuery_ShouldReturnStatusIdFromService()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetUserStatus((int)UserStatusEnum.ACTIVE)).Returns(new UserStatusEntity { Id = 2 });
            var target = new UserStatusQueries(_serviceMock.Object);

            // Act
            var result = target.ActiveQuery();

            // Assert
            result.Should().Be(2);
            _serviceMock.Verify(x => x.GetUserStatus((int)UserStatusEnum.ACTIVE), Times.Once);
        }

        [Fact]
        public void PendingQuery_ShouldReturnStatusIdFromService()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetUserStatus((int)UserStatusEnum.PENDING)).Returns(new UserStatusEntity { Id = 1 });
            var target = new UserStatusQueries(_serviceMock.Object);

            // Act
            var result = target.PendingQuery();

            // Assert
            result.Should().Be(1);
            _serviceMock.Verify(x => x.GetUserStatus((int)UserStatusEnum.PENDING), Times.Once);
        }

        [Fact]
        public void BanQuery_ShouldReturnStatusIdFromService()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetUserStatus((int)UserStatusEnum.BANNED)).Returns(new UserStatusEntity { Id = 4 });
            var target = new UserStatusQueries(_serviceMock.Object);

            // Act
            var result = target.BanQuery();

            // Assert
            result.Should().Be(4);
            _serviceMock.Verify(x => x.GetUserStatus((int)UserStatusEnum.BANNED), Times.Once);
        }

        [Fact]
        public void RevisionQuery_ShouldReturnStatusIdFromService()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetUserStatus((int)UserStatusEnum.REVISION)).Returns(new UserStatusEntity { Id = 3 });
            var target = new UserStatusQueries(_serviceMock.Object);

            // Act
            var result = target.RevisionQuery();

            // Assert
            result.Should().Be(3);
            _serviceMock.Verify(x => x.GetUserStatus((int)UserStatusEnum.REVISION), Times.Once);
        }

        [Fact]
        public void InactiveQuery_ShouldReturnStatusIdFromService()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetUserStatus((int)UserStatusEnum.INACTIVE)).Returns(new UserStatusEntity { Id = 5 });
            var target = new UserStatusQueries(_serviceMock.Object);

            // Act
            var result = target.InactiveQuery();

            // Assert
            result.Should().Be(5);
            _serviceMock.Verify(x => x.GetUserStatus((int)UserStatusEnum.INACTIVE), Times.Once);
        }

        [Fact]
        public void ActiveQuery_WhenServiceReturnsNull_ShouldThrow()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetUserStatus((int)UserStatusEnum.ACTIVE)).Returns((UserStatusEntity)null);
            var target = new UserStatusQueries(_serviceMock.Object);

            // Act
            Action act = () => target.ActiveQuery();

            // Assert
            act.Should().Throw<NullReferenceException>();
        }
    }
}
