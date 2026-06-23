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
    public class LocationCommandsTests
    {
        private readonly Mock<ILocationService> _serviceMock;

        public LocationCommandsTests()
        {
            _serviceMock = new Mock<ILocationService>();
        }

        [Fact]
        public void CreateCommand_ShouldMapDtoAndCallService()
        {
            // Arrange
            var dto = new LocationDto
            {
                Id = 1,
                Name = "Main Hall",
                Description = "Main room",
                Capacity = 120,
                EditionId = 5
            };
            var target = new LocationCommands(_serviceMock.Object);

            // Act
            target.CreateCommand(dto);

            // Assert
            _serviceMock.Verify(x => x.CreateLocation(It.Is<LocationEntity>(e =>
                e.Id == dto.Id
                && e.Name == dto.Name
                && e.Description == dto.Description
                && e.Capacity == dto.Capacity
                && e.EditionId == dto.EditionId)), Times.Once);
        }

        [Fact]
        public void CreateCommand_WhenDtoIsNull_ShouldCallServiceWithNullEntity()
        {
            // Arrange
            var target = new LocationCommands(_serviceMock.Object);

            // Act
            target.CreateCommand(null);

            // Assert
            _serviceMock.Verify(x => x.CreateLocation(null), Times.Once);
        }

        [Fact]
        public void UpdateCommand_ShouldMapDtoAndCallService()
        {
            // Arrange
            var dto = new LocationDto
            {
                Id = 2,
                Name = "Secondary",
                Description = "Updated",
                Capacity = 60,
                EditionId = 6
            };
            var target = new LocationCommands(_serviceMock.Object);

            // Act
            target.UpdateCommand(dto);

            // Assert
            _serviceMock.Verify(x => x.UpdateLocation(It.Is<LocationEntity>(e =>
                e.Id == dto.Id
                && e.Name == dto.Name
                && e.Description == dto.Description
                && e.Capacity == dto.Capacity
                && e.EditionId == dto.EditionId)), Times.Once);
        }

        [Fact]
        public void UpdateCommand_WhenDtoIsNull_ShouldCallServiceWithNullEntity()
        {
            // Arrange
            var target = new LocationCommands(_serviceMock.Object);

            // Act
            target.UpdateCommand(null);

            // Assert
            _serviceMock.Verify(x => x.UpdateLocation(null), Times.Once);
        }

        [Fact]
        public void DeleteCommand_ShouldCallServiceWithSameId()
        {
            // Arrange
            const int locationId = 44;
            var target = new LocationCommands(_serviceMock.Object);

            // Act
            target.DeleteCommand(locationId);

            // Assert
            _serviceMock.Verify(x => x.DeleteLocation(locationId), Times.Once);
        }
    }
}
