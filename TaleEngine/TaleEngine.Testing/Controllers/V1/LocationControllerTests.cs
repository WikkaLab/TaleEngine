using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Controllers.V1;
using TaleEngine.CQRS.Contracts;
using TaleEngine.Cross.Enums;
using Xunit;

namespace TaleEngine.Testing.Controllers.V1
{
    [ExcludeFromCodeCoverage]
    public class LocationControllerTests
    {
        [Fact]
        public void GetLocationsByEdition_Success()
        {
            int editionId = 1;
            Mock<ILocationQueries> queries = new();
            Mock<ILocationCommands> commands = new();
            var dto = new List<LocationDto> { new LocationDto { Id = 1, EditionId = editionId, Name = "Sala 1" } };

            queries.Setup(x => x.LocationsByEditionQuery(editionId)).Returns(dto);

            var target = new LocationController(queries.Object, commands.Object);

            IActionResult result = target.GetLocationsByEdition(editionId);

            var resultAsObjResult = result as ObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            queries.Verify(x => x.LocationsByEditionQuery(editionId), Times.Once);
        }

        [Fact]
        public void GetLocationsByEdition_EmptyResult_ReturnsNoContent()
        {
            int editionId = 1;
            Mock<ILocationQueries> queries = new();
            Mock<ILocationCommands> commands = new();

            queries.Setup(x => x.LocationsByEditionQuery(editionId)).Returns(new List<LocationDto>());

            var target = new LocationController(queries.Object, commands.Object);

            IActionResult result = target.GetLocationsByEdition(editionId);

            var resultAsObjResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public void GetLocation_NotFound_Returns404()
        {
            int locationId = 999;
            Mock<ILocationQueries> queries = new();
            Mock<ILocationCommands> commands = new();

            queries.Setup(x => x.GetLocationQuery(locationId)).Returns((LocationDto)null);

            var target = new LocationController(queries.Object, commands.Object);

            IActionResult result = target.GetLocation(locationId);

            var resultAsObjResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public void GetLocation_Success_Returns200()
        {
            int locationId = 2;
            Mock<ILocationQueries> queries = new();
            Mock<ILocationCommands> commands = new();

            queries.Setup(x => x.GetLocationQuery(locationId))
                .Returns(new LocationDto { Id = locationId, EditionId = 1, Name = "Sala A" });

            var target = new LocationController(queries.Object, commands.Object);

            IActionResult result = target.GetLocation(locationId);

            var resultAsObjResult = result as ObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public void CreateLocation_WithoutPermission_ReturnsUnauthorized()
        {
            int roleId = 1;
            var dto = new LocationDto { EditionId = 1, Name = "Sala" };
            Mock<ILocationQueries> queries = new();
            Mock<ILocationCommands> commands = new();
            Mock<IAssignedPermissionQueries> permissionQueries = new();

            permissionQueries.Setup(x => x.GetPermissionsByRoleQuery(roleId))
                .Returns(new List<AssignedPermissionDto>
                {
                    new AssignedPermissionDto
                    {
                        Permission = new PermissionDto { Abbr = "CRELOC" },
                        PermissionValueId = (int)PermissionValueEnum.DENY
                    }
                });

            var target = new LocationController(queries.Object, commands.Object);

            IActionResult result = target.CreateLocation(dto, roleId, permissionQueries.Object);

            var resultAsObjResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status401Unauthorized);
            commands.Verify(x => x.CreateCommand(It.IsAny<LocationDto>()), Times.Never);
        }

        [Fact]
        public void CreateLocation_WithPermission_ReturnsOk()
        {
            int roleId = 1;
            var dto = new LocationDto { EditionId = 1, Name = "Sala" };
            Mock<ILocationQueries> queries = new();
            Mock<ILocationCommands> commands = new();
            Mock<IAssignedPermissionQueries> permissionQueries = new();

            permissionQueries.Setup(x => x.GetPermissionsByRoleQuery(roleId))
                .Returns(new List<AssignedPermissionDto>
                {
                    new AssignedPermissionDto
                    {
                        Permission = new PermissionDto { Abbr = "CRELOC" },
                        PermissionValueId = (int)PermissionValueEnum.ALLOW
                    }
                });

            var target = new LocationController(queries.Object, commands.Object);

            IActionResult result = target.CreateLocation(dto, roleId, permissionQueries.Object);

            var resultAsObjResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            commands.Verify(x => x.CreateCommand(dto), Times.Once);
        }

        [Fact]
        public void UpdateLocation_WithoutPermission_ReturnsUnauthorized()
        {
            int roleId = 1;
            var dto = new LocationDto { Id = 1, EditionId = 1, Name = "Sala" };
            Mock<ILocationQueries> queries = new();
            Mock<ILocationCommands> commands = new();
            Mock<IAssignedPermissionQueries> permissionQueries = new();

            permissionQueries.Setup(x => x.GetPermissionsByRoleQuery(roleId))
                .Returns(new List<AssignedPermissionDto>
                {
                    new AssignedPermissionDto
                    {
                        Permission = new PermissionDto { Abbr = "EDITLOC" },
                        PermissionValueId = (int)PermissionValueEnum.DENY
                    }
                });

            var target = new LocationController(queries.Object, commands.Object);

            IActionResult result = target.UpdateLocation(dto, roleId, permissionQueries.Object);

            var resultAsObjResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status401Unauthorized);
            commands.Verify(x => x.UpdateCommand(It.IsAny<LocationDto>()), Times.Never);
        }

        [Fact]
        public void UpdateLocation_WithPermission_ReturnsOk()
        {
            int roleId = 1;
            var dto = new LocationDto { Id = 1, EditionId = 1, Name = "Sala" };
            Mock<ILocationQueries> queries = new();
            Mock<ILocationCommands> commands = new();
            Mock<IAssignedPermissionQueries> permissionQueries = new();

            permissionQueries.Setup(x => x.GetPermissionsByRoleQuery(roleId))
                .Returns(new List<AssignedPermissionDto>
                {
                    new AssignedPermissionDto
                    {
                        Permission = new PermissionDto { Abbr = "EDITLOC" },
                        PermissionValueId = (int)PermissionValueEnum.ALLOW
                    }
                });

            var target = new LocationController(queries.Object, commands.Object);

            IActionResult result = target.UpdateLocation(dto, roleId, permissionQueries.Object);

            var resultAsObjResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            commands.Verify(x => x.UpdateCommand(dto), Times.Once);
        }

        [Fact]
        public void DeleteLocation_WithoutPermission_ReturnsUnauthorized()
        {
            int roleId = 1;
            Mock<ILocationQueries> queries = new();
            Mock<ILocationCommands> commands = new();
            Mock<IAssignedPermissionQueries> permissionQueries = new();

            permissionQueries.Setup(x => x.GetPermissionsByRoleQuery(roleId))
                .Returns(new List<AssignedPermissionDto>
                {
                    new AssignedPermissionDto
                    {
                        Permission = new PermissionDto { Abbr = "DELLOC" },
                        PermissionValueId = (int)PermissionValueEnum.DENY
                    }
                });

            var target = new LocationController(queries.Object, commands.Object);

            IActionResult result = target.DeleteLocation(10, roleId, permissionQueries.Object);

            var resultAsObjResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status401Unauthorized);
            commands.Verify(x => x.DeleteCommand(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void DeleteLocation_WithPermission_ReturnsOk()
        {
            int roleId = 1;
            Mock<ILocationQueries> queries = new();
            Mock<ILocationCommands> commands = new();
            Mock<IAssignedPermissionQueries> permissionQueries = new();

            permissionQueries.Setup(x => x.GetPermissionsByRoleQuery(roleId))
                .Returns(new List<AssignedPermissionDto>
                {
                    new AssignedPermissionDto
                    {
                        Permission = new PermissionDto { Abbr = "DELLOC" },
                        PermissionValueId = (int)PermissionValueEnum.ALLOW
                    }
                });

            var target = new LocationController(queries.Object, commands.Object);

            IActionResult result = target.DeleteLocation(10, roleId, permissionQueries.Object);

            var resultAsObjResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            commands.Verify(x => x.DeleteCommand(10), Times.Once);
        }
    }
}
