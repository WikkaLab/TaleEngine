using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Queries.Backoffice;
using TaleEngine.Cross.Enums;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class UserQueriesTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IUserStatusQueries> _userStatusQueriesMock;

        public UserQueriesTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _userStatusQueriesMock = new Mock<IUserStatusQueries>();
        }

        [Fact]
        public void AllUsersQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetAllUsers()).Returns((List<UserEntity>)null);
            var target = BuildTarget();

            // Act
            var result = target.AllUsersQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AllUsersQuery_WhenServiceReturnsEmpty_ShouldReturnNull()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetAllUsers()).Returns(new List<UserEntity>());
            var target = BuildTarget();

            // Act
            var result = target.AllUsersQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AllUsersQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetAllUsers()).Returns(new List<UserEntity>
            {
                new UserEntity
                {
                    Id = 1,
                    Username = "alice",
                    Name = "Alice",
                    Mail = "alice@site.com",
                    Website = "https://site.com",
                    Blog = "https://blog.site.com",
                    StatusId = (int)UserStatusEnum.ACTIVE
                }
            });
            var target = BuildTarget();

            // Act
            var result = target.AllUsersQuery();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Username.Should().Be("alice");
            result[0].Mail.Should().Be("alice@site.com");
        }

        [Fact]
        public void UserQuery_WhenUserIdIsZero_ShouldReturnNullAndSkipService()
        {
            // Arrange
            var target = BuildTarget();

            // Act
            var result = target.UserQuery(0);

            // Assert
            result.Should().BeNull();
            _userServiceMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void UserQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetById(9)).Returns((UserEntity)null);
            var target = BuildTarget();

            // Act
            var result = target.UserQuery(9);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void UserQuery_WhenServiceReturnsEntity_ShouldReturnMappedDto()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetById(9)).Returns(new UserEntity
            {
                Id = 9,
                Username = "bob",
                Name = "Bob",
                Mail = "bob@site.com",
                Website = "https://bob.com",
                Blog = "https://blog.bob.com",
                StatusId = (int)UserStatusEnum.PENDING
            });
            var target = BuildTarget();

            // Act
            var result = target.UserQuery(9);

            // Assert
            result.Should().NotBeNull();
            result.Username.Should().Be("bob");
            result.Name.Should().Be("Bob");
            result.Mail.Should().Be("bob@site.com");
        }

        private UserQueries BuildTarget()
        {
            return new UserQueries(_userServiceMock.Object, _userStatusQueriesMock.Object);
        }
    }
}
