using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using TaleEngine.CQRS.Queries;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class LocationQueriesTests
    {
        private readonly Mock<ILocationService> _serviceMock;

        public LocationQueriesTests()
        {
            _serviceMock = new Mock<ILocationService>();
        }

        [Fact]
        public void GetLocationQuery_WhenEntityExists_ShouldReturnMappedDto()
        {
            // Arrange
            const int locationId = 8;
            _serviceMock.Setup(x => x.GetById(locationId)).Returns(new LocationEntity
            {
                Id = locationId,
                Name = "Room A",
                Description = "Desc",
                Capacity = 40,
                EditionId = 2
            });
            var target = new LocationQueries(_serviceMock.Object);

            // Act
            var result = target.GetLocationQuery(locationId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(locationId);
            result.Name.Should().Be("Room A");
        }

        [Fact]
        public void GetLocationQuery_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns((LocationEntity)null);
            var target = new LocationQueries(_serviceMock.Object);

            // Act
            var result = target.GetLocationQuery(9);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void LocationsByEditionQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetByEdition(It.IsAny<int>())).Returns((List<LocationEntity>)null);
            var target = new LocationQueries(_serviceMock.Object);

            // Act
            var result = target.LocationsByEditionQuery(2);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void LocationsByEditionQuery_WhenServiceReturnsEmpty_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetByEdition(It.IsAny<int>())).Returns(new List<LocationEntity>());
            var target = new LocationQueries(_serviceMock.Object);

            // Act
            var result = target.LocationsByEditionQuery(2);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void LocationsByEditionQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetByEdition(2)).Returns(new List<LocationEntity>
            {
                new LocationEntity { Id = 1, Name = "A", Description = "D1", Capacity = 10, EditionId = 2 },
                new LocationEntity { Id = 2, Name = "B", Description = "D2", Capacity = 20, EditionId = 2 }
            });
            var target = new LocationQueries(_serviceMock.Object);

            // Act
            var result = target.LocationsByEditionQuery(2);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[1].Name.Should().Be("B");
        }
    }
}
