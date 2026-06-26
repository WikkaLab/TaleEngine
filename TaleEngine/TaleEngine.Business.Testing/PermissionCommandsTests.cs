using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Commands;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class PermissionCommandsTests
    {
        private readonly Mock<IPermissionService> _serviceMock;

        public PermissionCommandsTests()
        {
            _serviceMock = new Mock<IPermissionService>();
        }

        [Fact]
        public void CreateCommand_ShouldMapDtoAndCallService()
        {
            // Arrange
            var dto = new PermissionDto { Id = 1, Name = "Read", Abbr = "R", Description = "Read access" };
            var target = new PermissionCommands(_serviceMock.Object);

            // Act
            target.CreateCommand(dto);

            // Assert
            _serviceMock.Verify(x => x.CreatePermission(It.Is<PermissionEntity>(e =>
                e.Id == dto.Id && e.Name == dto.Name && e.Abbr == dto.Abbr && e.Description == dto.Description)), Times.Once);
        }

        [Fact]
        public void CreateCommand_WhenDtoIsNull_ShouldCallServiceWithNullEntity()
        {
            // Arrange
            var target = new PermissionCommands(_serviceMock.Object);

            // Act
            target.CreateCommand(null);

            // Assert
            _serviceMock.Verify(x => x.CreatePermission(null), Times.Once);
        }

        [Fact]
        public void UpdateCommand_ShouldMapDtoAndCallService()
        {
            // Arrange
            var dto = new PermissionDto { Id = 2, Name = "Write", Abbr = "W", Description = "Write access" };
            var target = new PermissionCommands(_serviceMock.Object);

            // Act
            target.UpdateCommand(dto);

            // Assert
            _serviceMock.Verify(x => x.UpdatePermission(It.Is<PermissionEntity>(e =>
                e.Id == dto.Id && e.Name == dto.Name && e.Abbr == dto.Abbr && e.Description == dto.Description)), Times.Once);
        }

        [Fact]
        public void UpdateCommand_WhenDtoIsNull_ShouldCallServiceWithNullEntity()
        {
            // Arrange
            var target = new PermissionCommands(_serviceMock.Object);

            // Act
            target.UpdateCommand(null);

            // Assert
            _serviceMock.Verify(x => x.UpdatePermission(null), Times.Once);
        }

        [Fact]
        public void DeleteCommand_ShouldCallServiceWithSameId()
        {
            // Arrange
            const int permissionId = 88;
            var target = new PermissionCommands(_serviceMock.Object);

            // Act
            target.DeleteCommand(permissionId);

            // Assert
            _serviceMock.Verify(x => x.DeletePermission(permissionId), Times.Once);
        }
    }
}
