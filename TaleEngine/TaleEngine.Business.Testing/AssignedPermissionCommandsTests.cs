using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.CQRS.Commands;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class AssignedPermissionCommandsTests
    {
        private readonly Mock<IAssignedPermissionService> _serviceMock;

        public AssignedPermissionCommandsTests()
        {
            _serviceMock = new Mock<IAssignedPermissionService>();
        }

        [Fact]
        public void AssignPermissionCommand_ShouldCallServiceWithRequestValues()
        {
            // Arrange
            var request = new AssignPermissionRequest
            {
                RoleId = 2,
                PermissionId = 3,
                PermissionValueId = 4
            };
            var target = new AssignedPermissionCommands(_serviceMock.Object);

            // Act
            target.AssignPermissionCommand(request);

            // Assert
            _serviceMock.Verify(x => x.AssignPermissionToRole(request.RoleId, request.PermissionId, request.PermissionValueId), Times.Once);
        }

        [Fact]
        public void RemovePermissionCommand_ShouldCallServiceWithRequestValues()
        {
            // Arrange
            var request = new AssignPermissionRequest
            {
                RoleId = 5,
                PermissionId = 6,
                PermissionValueId = 7
            };
            var target = new AssignedPermissionCommands(_serviceMock.Object);

            // Act
            target.RemovePermissionCommand(request);

            // Assert
            _serviceMock.Verify(x => x.RemovePermissionFromRole(request.RoleId, request.PermissionId, request.PermissionValueId), Times.Once);
        }
    }
}
