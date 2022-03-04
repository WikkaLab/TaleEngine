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

namespace TaleEngine.Testing.Controllers.V2
{
    [ExcludeFromCodeCoverage]
    public class RolesControllerTests
    {
        [Fact]
        public void GetRoles_Success()
        {
            // Act
            List<RoleDto> dto = new()
            {
                new RoleDto()
            };

            Mock<IRoleCommands> serviceMock = new();
            serviceMock.Setup(x => x.AllRolesQuery())
                .Returns(dto);

            RolesController target = new(serviceMock.Object);

            // Act
            var result = target.GetAllRoles();

            // Assert
            ObjectResult resultAsObjResult = result as OkObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.AllRolesQuery(), Times.Once);
        }

        [Fact]
        public void GetRoles_EmtpyResult_Success()
        {
            // Act
            List<RoleDto> dto = new();

            Mock<IRoleCommands> serviceMock = new();
            serviceMock.Setup(x => x.AllRolesQuery())
                .Returns(dto);

            RolesController target = new(serviceMock.Object);

            // Act
            var result = target.GetAllRoles();

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.AllRolesQuery(), Times.Once);
        }

        [Fact]
        public void GetRoles_NullResult_Success()
        {
            // Act
            List<RoleDto> dto = null;

            Mock<IRoleCommands> serviceMock = new();
            serviceMock.Setup(x => x.AllRolesQuery())
                .Returns(dto);

            RolesController target = new(serviceMock.Object);

            // Act
            var result = target.GetAllRoles();

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.AllRolesQuery(), Times.Once);
        }

        [Fact]
        public void GetRole_Success()
        {
            // Arrange
            int roleId = 1;
            Mock<IRoleCommands> serviceMock = new();

            RolesController target = new(serviceMock.Object);

            // Act
            var result = target.GetRole(roleId);

            // Assert
            var resultAsObjResult = result as OkResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
