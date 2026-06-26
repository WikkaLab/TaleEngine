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
    public class PermissionValueCommandsTests
    {
        private readonly Mock<IPermissionValueService> _serviceMock;

        public PermissionValueCommandsTests()
        {
            _serviceMock = new Mock<IPermissionValueService>();
        }

        [Fact]
        public void CreateCommand_ShouldMapDtoAndCallService()
        {
            // Arrange
            var dto = new PermissionValueDto { Id = 1, Name = "Allow", Abbr = "ALL", Description = "Allow action" };
            var target = new PermissionValueCommands(_serviceMock.Object);

            // Act
            target.CreateCommand(dto);

            // Assert
            _serviceMock.Verify(x => x.CreatePermissionValue(It.Is<PermissionValueEntity>(e =>
                e.Id == dto.Id && e.Name == dto.Name && e.Abbr == dto.Abbr && e.Description == dto.Description)), Times.Once);
        }

        [Fact]
        public void CreateCommand_WhenDtoIsNull_ShouldCallServiceWithNullEntity()
        {
            // Arrange
            var target = new PermissionValueCommands(_serviceMock.Object);

            // Act
            target.CreateCommand(null);

            // Assert
            _serviceMock.Verify(x => x.CreatePermissionValue(null), Times.Once);
        }

        [Fact]
        public void UpdateCommand_ShouldMapDtoAndCallService()
        {
            // Arrange
            var dto = new PermissionValueDto { Id = 2, Name = "Deny", Abbr = "DEN", Description = "Deny action" };
            var target = new PermissionValueCommands(_serviceMock.Object);

            // Act
            target.UpdateCommand(dto);

            // Assert
            _serviceMock.Verify(x => x.UpdatePermissionValue(It.Is<PermissionValueEntity>(e =>
                e.Id == dto.Id && e.Name == dto.Name && e.Abbr == dto.Abbr && e.Description == dto.Description)), Times.Once);
        }

        [Fact]
        public void UpdateCommand_WhenDtoIsNull_ShouldCallServiceWithNullEntity()
        {
            // Arrange
            var target = new PermissionValueCommands(_serviceMock.Object);

            // Act
            target.UpdateCommand(null);

            // Assert
            _serviceMock.Verify(x => x.UpdatePermissionValue(null), Times.Once);
        }

        [Fact]
        public void DeleteCommand_ShouldCallServiceWithSameId()
        {
            // Arrange
            const int permissionValueId = 35;
            var target = new PermissionValueCommands(_serviceMock.Object);

            // Act
            target.DeleteCommand(permissionValueId);

            // Assert
            _serviceMock.Verify(x => x.DeletePermissionValue(permissionValueId), Times.Once);
        }
    }
}
