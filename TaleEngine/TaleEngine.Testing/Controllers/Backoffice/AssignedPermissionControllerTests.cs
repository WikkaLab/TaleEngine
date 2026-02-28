using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Controllers.Backoffice;
using TaleEngine.CQRS.Contracts;
using Xunit;

namespace TaleEngine.API.Testing.Controllers.Backoffice
{
    [ExcludeFromCodeCoverage]
    public class AssignedPermissionControllerTests
    {
        [Fact]
        public void GetAllAssignedPermissions_Success()
        {
            // Arrange
            List<AssignedPermissionDto> dto = new()
            {
                new AssignedPermissionDto 
                { 
                    Id = 1, 
                    RoleId = 1, 
                    PermissionId = 1, 
                    PermissionValueId = 1 
                }
            };

            Mock<IAssignedPermissionQueries> queriesMock = new();
            queriesMock.Setup(x => x.AllAssignedPermissionsQuery())
                .Returns(dto);

            Mock<IAssignedPermissionCommands> commandsMock = new();

            AssignedPermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.GetAllAssignedPermissions();

            // Assert
            ObjectResult resultAsObjResult = result as OkObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            queriesMock.Verify(x => x.AllAssignedPermissionsQuery(), Times.Once);
        }

        [Fact]
        public void GetPermissionsByRole_Success()
        {
            // Arrange
            int roleId = 1;
            List<AssignedPermissionDto> dto = new()
            {
                new AssignedPermissionDto 
                { 
                    Id = 1, 
                    RoleId = roleId, 
                    PermissionId = 1, 
                    PermissionValueId = 1 
                }
            };

            Mock<IAssignedPermissionQueries> queriesMock = new();
            queriesMock.Setup(x => x.GetPermissionsByRoleQuery(roleId))
                .Returns(dto);

            Mock<IAssignedPermissionCommands> commandsMock = new();

            AssignedPermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.GetPermissionsByRole(roleId);

            // Assert
            ObjectResult resultAsObjResult = result as OkObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            queriesMock.Verify(x => x.GetPermissionsByRoleQuery(roleId), Times.Once);
        }

        [Fact]
        public void GetPermissionsByRole_EmptyResult_ReturnsNoContent()
        {
            // Arrange
            int roleId = 999;
            List<AssignedPermissionDto> dto = new();

            Mock<IAssignedPermissionQueries> queriesMock = new();
            queriesMock.Setup(x => x.GetPermissionsByRoleQuery(roleId))
                .Returns(dto);

            Mock<IAssignedPermissionCommands> commandsMock = new();

            AssignedPermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.GetPermissionsByRole(roleId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            queriesMock.Verify(x => x.GetPermissionsByRoleQuery(roleId), Times.Once);
        }

        [Fact]
        public void AssignPermission_Success()
        {
            // Arrange
            AssignPermissionRequest request = new() 
            { 
                RoleId = 1, 
                PermissionId = 1, 
                PermissionValueId = 1 
            };

            Mock<IAssignedPermissionQueries> queriesMock = new();
            Mock<IAssignedPermissionCommands> commandsMock = new();

            AssignedPermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.AssignPermission(request);

            // Assert
            var resultAsObjResult = result as OkResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commandsMock.Verify(x => x.AssignPermissionCommand(request), Times.Once);
        }

        [Fact]
        public void RemovePermission_Success()
        {
            // Arrange
            AssignPermissionRequest request = new() 
            { 
                RoleId = 1, 
                PermissionId = 1, 
                PermissionValueId = 1 
            };

            Mock<IAssignedPermissionQueries> queriesMock = new();
            Mock<IAssignedPermissionCommands> commandsMock = new();

            AssignedPermissionController target = new(queriesMock.Object, commandsMock.Object);

            // Act
            var result = target.RemovePermission(request);

            // Assert
            var resultAsObjResult = result as OkResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commandsMock.Verify(x => x.RemovePermissionCommand(request), Times.Once);
        }
    }
}
