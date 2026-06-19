using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.Services.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class LocationServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<TaleEngine.Data.Contracts.Repositories.ILocationRepository> _locationRepositoryMock;

        public LocationServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _locationRepositoryMock = new Mock<TaleEngine.Data.Contracts.Repositories.ILocationRepository>();
            _unitOfWorkMock.Setup(x => x.LocationRepository).Returns(_locationRepositoryMock.Object);
        }

        [Fact]
        public void GetById_Success()
        {
            // Arrange
            var location = new LocationEntity { Id = 4, Name = "Sala Roja", EditionId = 1, Capacity = 30 };

            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(4))
                .Returns(location);

            var service = new LocationService(_unitOfWorkMock.Object);

            // Act
            var result = service.GetById(4);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(4);
            result.Name.Should().Be("Sala Roja");
        }

        [Fact]
        public void GetByEdition_Success()
        {
            // Arrange
            var locations = new List<LocationEntity>
            {
                new LocationEntity { Id = 1, Name = "Sala 1", EditionId = 1, Capacity = 20 },
                new LocationEntity { Id = 2, Name = "Sala 2", EditionId = 1, Capacity = 25 }
            };

            _unitOfWorkMock.Setup(x => x.LocationRepository.GetByEdition(1))
                .Returns(locations);

            var service = new LocationService(_unitOfWorkMock.Object);

            // Act
            var result = service.GetByEdition(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }

        [Fact]
        public void CreateLocation_Success()
        {
            // Arrange
            var location = new LocationEntity { Name = "Sala Nueva", EditionId = 1, Capacity = 40 };
            var service = new LocationService(_unitOfWorkMock.Object);

            // Act
            service.CreateLocation(location);

            // Assert
            _unitOfWorkMock.Verify(x => x.LocationRepository.Insert(location), Times.Once);
            _unitOfWorkMock.Verify(x => x.LocationRepository.Save(), Times.Once);
        }

        [Fact]
        public void UpdateLocation_Success()
        {
            // Arrange
            var location = new LocationEntity { Id = 3, Name = "Sala Editada", EditionId = 1, Capacity = 50 };
            var service = new LocationService(_unitOfWorkMock.Object);

            // Act
            service.UpdateLocation(location);

            // Assert
            _unitOfWorkMock.Verify(x => x.LocationRepository.Update(location), Times.Once);
            _unitOfWorkMock.Verify(x => x.LocationRepository.Save(), Times.Once);
        }

        [Fact]
        public void DeleteLocation_Success()
        {
            // Arrange
            var service = new LocationService(_unitOfWorkMock.Object);

            // Act
            service.DeleteLocation(9);

            // Assert
            _unitOfWorkMock.Verify(x => x.LocationRepository.Delete(9), Times.Once);
            _unitOfWorkMock.Verify(x => x.LocationRepository.Save(), Times.Once);
        }
    }
}