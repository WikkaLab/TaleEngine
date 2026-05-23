using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Controllers.V1;
using TaleEngine.CQRS.Contracts;
using Xunit;

namespace TaleEngine.Testing.Controllers.V1
{
    [ExcludeFromCodeCoverage]
    public class UserControllerTests
    {
        [Fact]
        public void GetUserProfile_Success()
        {
            // Arrange
            int userId = 1;
            Mock<IUserCommands> commands = new();
            Mock<IUserQueries> queries = new();
            UserDto dto = new() { Username = "user" };

            queries.Setup(x => x.UserQuery(userId))
                .Returns(dto);

            UserController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetUserProfile(userId);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            queries.Verify(x => x.UserQuery(userId), Times.Once);
        }

        [Fact]
        public void GetUserProfile_NullResult_ReturnsNoContent()
        {
            // Arrange
            int userId = 1;
            Mock<IUserCommands> commands = new();
            Mock<IUserQueries> queries = new();

            queries.Setup(x => x.UserQuery(userId))
                .Returns((UserDto)null);

            UserController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetUserProfile(userId);

            // Assert
            var resultAsStatusCode = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsStatusCode.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            queries.Verify(x => x.UserQuery(userId), Times.Once);
        }

        [Fact]
        public void Register_Success()
        {
            // Arrange
            Mock<IUserCommands> commands = new();
            Mock<IUserQueries> queries = new();

            UserDto request = new() { Username = "newuser", Mail = "mail@test.com" };
            UserDto response = new() { Username = "newuser", Mail = "mail@test.com" };

            commands.Setup(x => x.RegisterCommand(request))
                .Returns(response);

            UserController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.Register(request);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commands.Verify(x => x.RegisterCommand(request), Times.Once);
        }

        [Fact]
        public void Register_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            Mock<IUserCommands> commands = new();
            Mock<IUserQueries> queries = new();

            UserDto request = new();

            commands.Setup(x => x.RegisterCommand(request))
                .Returns((UserDto)null);

            UserController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.Register(request);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            commands.Verify(x => x.RegisterCommand(request), Times.Once);
        }

        [Fact]
        public void UpdateProfile_Success()
        {
            // Arrange
            int userId = 1;
            Mock<IUserCommands> commands = new();
            Mock<IUserQueries> queries = new();
            UserDto request = new() { Name = "Updated" };

            UserController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.UpdateProfile(userId, request);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commands.Verify(x => x.UpdateProfileCommand(userId, request), Times.Once);
        }

        [Fact]
        public void UpdateProfile_InvalidUserId_ReturnsBadRequest()
        {
            // Arrange
            int userId = 0;
            Mock<IUserCommands> commands = new();
            Mock<IUserQueries> queries = new();
            UserDto request = new() { Name = "Updated" };

            UserController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.UpdateProfile(userId, request);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            commands.Verify(x => x.UpdateProfileCommand(It.IsAny<int>(), It.IsAny<UserDto>()), Times.Never);
        }
    }
}
