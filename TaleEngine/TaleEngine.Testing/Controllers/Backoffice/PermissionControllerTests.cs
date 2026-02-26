using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Controllers.V2;
using TaleEngine.CQRS.Contracts;
using Xunit;

namespace TaleEngine.API.Testing.Controllers.Backoffice
{
    [ExcludeFromCodeCoverage]
    public class PermissionControllerTests
    {
        [Fact]
        public void GetPermissions_Success()
        {
            // Arrange
            List<PermissionDto> dto = new()
            {
                new PermissionDto { Id = 1, Name = "Test Permission", Abbr = "TEST" }
            };

            Mock<IPermissionQueries> queriesMock = new();
            queriesMock.Setup(x => x.AllPermissionsQuery())
                .Returns(dto);

            Mock<IPermissionCommands> commandsMock = new();

            PermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.GetPermissions();

            // Assert
            ObjectResult resultAsObjResult = result as OkObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            queriesMock.Verify(x => x.AllPermissionsQuery(), Times.Once);
        }

        [Fact]
        public void GetPermissions_EmptyResult_ReturnsNoContent()
        {
            // Arrange
            List<PermissionDto> dto = new();

            Mock<IPermissionQueries> queriesMock = new();
            queriesMock.Setup(x => x.AllPermissionsQuery())
                .Returns(dto);

            Mock<IPermissionCommands> commandsMock = new();

            PermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.GetPermissions();

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            queriesMock.Verify(x => x.AllPermissionsQuery(), Times.Once);
        }

        [Fact]
        public void GetPermission_Success()
        {
            // Arrange
            int permissionId = 1;
            PermissionDto dto = new() { Id = permissionId, Name = "Test Permission", Abbr = "TEST" };

            Mock<IPermissionQueries> queriesMock = new();
            queriesMock.Setup(x => x.GetPermissionQuery(permissionId))
                .Returns(dto);

            Mock<IPermissionCommands> commandsMock = new();

            PermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.GetPermission(permissionId);

            // Assert
            ObjectResult resultAsObjResult = result as OkObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            queriesMock.Verify(x => x.GetPermissionQuery(permissionId), Times.Once);
        }

        [Fact]
        public void GetPermission_NotFound()
        {
            // Arrange
            int permissionId = 999;

            Mock<IPermissionQueries> queriesMock = new();
            queriesMock.Setup(x => x.GetPermissionQuery(permissionId))
                .Returns((PermissionDto)null);

            Mock<IPermissionCommands> commandsMock = new();

            PermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.GetPermission(permissionId);

            // Assert
            var resultAsObjResult = result as NotFoundResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);

            queriesMock.Verify(x => x.GetPermissionQuery(permissionId), Times.Once);
        }

        [Fact]
        public void CreatePermission_Success()
        {
            // Arrange
            PermissionDto dto = new() { Name = "New Permission", Abbr = "NEW" };

            Mock<IPermissionQueries> queriesMock = new();
            Mock<IPermissionCommands> commandsMock = new();

            PermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.CreatePermission(dto);

            // Assert
            var resultAsObjResult = result as OkResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commandsMock.Verify(x => x.CreateCommand(dto), Times.Once);
        }

        [Fact]
        public void UpdatePermission_Success()
        {
            // Arrange
            PermissionDto dto = new() { Id = 1, Name = "Updated Permission", Abbr = "UPD" };

            Mock<IPermissionQueries> queriesMock = new();
            Mock<IPermissionCommands> commandsMock = new();

            PermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.UpdatePermission(dto);

            // Assert
            var resultAsObjResult = result as OkResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commandsMock.Verify(x => x.UpdateCommand(dto), Times.Once);
        }

        [Fact]
        public void DeletePermission_Success()
        {
            // Arrange
            int permissionId = 1;

            Mock<IPermissionQueries> queriesMock = new();
            Mock<IPermissionCommands> commandsMock = new();

            PermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.DeletePermission(permissionId);

            // Assert
            var resultAsObjResult = result as OkResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commandsMock.Verify(x => x.DeleteCommand(permissionId), Times.Once);
        }
    }
}
