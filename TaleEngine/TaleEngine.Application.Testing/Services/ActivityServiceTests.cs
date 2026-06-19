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
    public class ActivityServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IActivityStatusService> _activityStatusServiceMock;

        public ActivityServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _activityStatusServiceMock = new Mock<IActivityStatusService>();
        }

        [Fact]
        public void CreateActivity_LocationNotFound_ReturnsZero()
        {
            // Arrange
            var locationId = 10;
            var activity = BuildActivity(locationId: locationId);

            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(locationId))
                .Returns((LocationEntity)null);

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.CreateActivity(1, activity);

            // Assert
            result.Should().Be(0);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Insert(It.IsAny<ActivityEntity>()), Times.Never);
        }

        [Fact]
        public void CreateActivity_LocationFromDifferentEdition_ReturnsZero()
        {
            // Arrange
            var locationId = 10;
            var activity = BuildActivity(locationId: locationId);

            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(locationId))
                .Returns(new LocationEntity { Id = locationId, EditionId = 2, Capacity = 20 });

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.CreateActivity(1, activity);

            // Assert
            result.Should().Be(0);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Insert(It.IsAny<ActivityEntity>()), Times.Never);
        }

        [Fact]
        public void CreateActivity_PlacesExceedLocationCapacity_ReturnsZero()
        {
            // Arrange
            var locationId = 10;
            var activity = BuildActivity(places: 50, locationId: locationId);

            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(locationId))
                .Returns(new LocationEntity { Id = locationId, EditionId = 1, Capacity = 20 });

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.CreateActivity(1, activity);

            // Assert
            result.Should().Be(0);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Insert(It.IsAny<ActivityEntity>()), Times.Never);
        }

        [Fact]
        public void CreateActivity_LocationAndTimeSlotConflict_ReturnsZero()
        {
            // Arrange
            var locationId = 10;
            var timeSlotId = 3;
            var activity = BuildActivity(locationId: locationId, timeSlotId: timeSlotId);

            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(locationId))
                .Returns(new LocationEntity { Id = locationId, EditionId = 1, Capacity = 20 });
            _unitOfWorkMock.Setup(x => x.ActivityRepository.GetAll())
                .Returns(new List<ActivityEntity>
                {
                    new ActivityEntity
                    {
                        Id = 44,
                        EditionId = 1,
                        LocationId = locationId,
                        TimeSlotId = timeSlotId
                    }
                });

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.CreateActivity(1, activity);

            // Assert
            result.Should().Be(0);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Insert(It.IsAny<ActivityEntity>()), Times.Never);
        }

        [Fact]
        public void CreateActivity_ValidLocationAssignment_ReturnsOne()
        {
            // Arrange
            var locationId = 10;
            var activity = BuildActivity(locationId: locationId);

            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(locationId))
                .Returns(new LocationEntity { Id = locationId, EditionId = 1, Capacity = 20 });
            _unitOfWorkMock.Setup(x => x.ActivityRepository.GetAll())
                .Returns(new List<ActivityEntity>());

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.CreateActivity(1, activity);

            // Assert
            result.Should().Be(1);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Insert(It.Is<ActivityEntity>(a => a.LocationId == locationId)), Times.Once);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Save(), Times.Once);
        }

        [Fact]
        public void CreateActivity_WithoutLocation_ReturnsOne()
        {
            // Arrange
            var activity = BuildActivity();
            _unitOfWorkMock.Setup(x => x.ActivityRepository.GetAll())
                .Returns(new List<ActivityEntity>());

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.CreateActivity(1, activity);

            // Assert
            result.Should().Be(1);
            _unitOfWorkMock.Verify(x => x.LocationRepository.GetById(It.IsAny<int>()), Times.Never);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Insert(It.Is<ActivityEntity>(a => a.LocationId == null)), Times.Once);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Save(), Times.Once);
        }

        [Fact]
        public void UpdateActivity_WhenAnotherActivityUsesSameLocationAndTimeSlot_ReturnsZero()
        {
            // Arrange
            var locationId = 10;
            var timeSlotId = 2;
            var updated = BuildActivity(locationId: locationId, timeSlotId: timeSlotId);

            _unitOfWorkMock.Setup(x => x.ActivityRepository.GetById(1))
                .Returns(new ActivityEntity
                {
                    Id = 1,
                    EditionId = 1,
                    Places = 5,
                    TimeSlotId = 1
                });
            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(locationId))
                .Returns(new LocationEntity { Id = locationId, EditionId = 1, Capacity = 20 });
            _unitOfWorkMock.Setup(x => x.ActivityRepository.GetAll())
                .Returns(new List<ActivityEntity>
                {
                    new ActivityEntity
                    {
                        Id = 99,
                        EditionId = 1,
                        LocationId = locationId,
                        TimeSlotId = timeSlotId
                    }
                });

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.UpdateActivity(1, updated);

            // Assert
            result.Should().Be(0);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Update(It.IsAny<ActivityEntity>()), Times.Never);
        }

        [Fact]
        public void UpdateActivity_LocationNotFound_ReturnsZero()
        {
            // Arrange
            var locationId = 10;
            var updated = BuildActivity(locationId: locationId, timeSlotId: 2);

            _unitOfWorkMock.Setup(x => x.ActivityRepository.GetById(1))
                .Returns(new ActivityEntity
                {
                    Id = 1,
                    EditionId = 1,
                    Places = 5,
                    TimeSlotId = 1
                });
            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(locationId))
                .Returns((LocationEntity)null);

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.UpdateActivity(1, updated);

            // Assert
            result.Should().Be(0);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Update(It.IsAny<ActivityEntity>()), Times.Never);
        }

        [Fact]
        public void UpdateActivity_LocationFromDifferentEdition_ReturnsZero()
        {
            // Arrange
            var locationId = 10;
            var updated = BuildActivity(locationId: locationId, timeSlotId: 2);

            _unitOfWorkMock.Setup(x => x.ActivityRepository.GetById(1))
                .Returns(new ActivityEntity
                {
                    Id = 1,
                    EditionId = 1,
                    Places = 5,
                    TimeSlotId = 1
                });
            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(locationId))
                .Returns(new LocationEntity { Id = locationId, EditionId = 2, Capacity = 20 });

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.UpdateActivity(1, updated);

            // Assert
            result.Should().Be(0);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Update(It.IsAny<ActivityEntity>()), Times.Never);
        }

        [Fact]
        public void UpdateActivity_PlacesExceedLocationCapacity_ReturnsZero()
        {
            // Arrange
            var locationId = 10;
            var updated = BuildActivity(places: 25, locationId: locationId, timeSlotId: 2);

            _unitOfWorkMock.Setup(x => x.ActivityRepository.GetById(1))
                .Returns(new ActivityEntity
                {
                    Id = 1,
                    EditionId = 1,
                    Places = 5,
                    TimeSlotId = 1
                });
            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(locationId))
                .Returns(new LocationEntity { Id = locationId, EditionId = 1, Capacity = 20 });

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.UpdateActivity(1, updated);

            // Assert
            result.Should().Be(0);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Update(It.IsAny<ActivityEntity>()), Times.Never);
        }

        [Fact]
        public void UpdateActivity_ValidLocationAssignment_ReturnsOne()
        {
            // Arrange
            var locationId = 10;
            var updated = BuildActivity(locationId: locationId, timeSlotId: 2);

            _unitOfWorkMock.Setup(x => x.ActivityRepository.GetById(1))
                .Returns(new ActivityEntity
                {
                    Id = 1,
                    EditionId = 1,
                    Places = 5,
                    TimeSlotId = 1,
                    LocationId = null
                });
            _unitOfWorkMock.Setup(x => x.LocationRepository.GetById(locationId))
                .Returns(new LocationEntity { Id = locationId, EditionId = 1, Capacity = 20 });
            _unitOfWorkMock.Setup(x => x.ActivityRepository.GetAll())
                .Returns(new List<ActivityEntity>());

            var service = new ActivityService(_unitOfWorkMock.Object, _activityStatusServiceMock.Object);

            // Act
            var result = service.UpdateActivity(1, updated);

            // Assert
            result.Should().Be(1);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Update(It.Is<ActivityEntity>(a => a.LocationId == locationId)), Times.Once);
            _unitOfWorkMock.Verify(x => x.ActivityRepository.Save(), Times.Once);
        }

        private static Activity BuildActivity(int places = 5, int typeId = 1, int statusId = 1, int timeSlotId = 1, int locationId = 0)
        {
            var activity = new Activity()
                .SetTitle("Actividad")
                .SetDescription("Desc")
                .SetPlaces(places)
                .SetType(typeId)
                .SetStatus(statusId)
                .SetTimeSlot(timeSlotId)
                .SetImage("img");

            if (locationId > 0)
            {
                activity.SetLocation(locationId);
            }

            return activity;
        }
    }
}
