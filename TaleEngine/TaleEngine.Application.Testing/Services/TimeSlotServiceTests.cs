using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Services;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.DbServices.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class TimeSlotServiceTests
    {
        private Mock<IUnitOfWork> mock;

        public TimeSlotServiceTests()
        {
            mock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void GetTimeSlots_Success()
        {
            // Arrange
            List<TimeSlotEntity> list = TimeSlotBuilder.BuildTimeSlotList();

            mock.Setup(x => x.TimeSlotRepository.GetAll())
                .Returns(list);

            TimeSlotService service = new TimeSlotService(mock.Object);

            // Act
            var result = service.GetTimeSlots();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetTimeSlots_ReturnsEmpty_Success()
        {
            // Arrange
            List<TimeSlotEntity> list = new();

            mock.Setup(x => x.TimeSlotRepository.GetAll())
                .Returns(list);

            TimeSlotService service = new TimeSlotService(mock.Object);

            // Act
            var result = service.GetTimeSlots();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void GetTimeSlots_ReturnsNull_Success()
        {
            // Arrange
            List<TimeSlotEntity> list = null;

            mock.Setup(x => x.TimeSlotRepository.GetAll())
                .Returns(list);

            TimeSlotService service = new TimeSlotService(mock.Object);

            // Act
            var result = service.GetTimeSlots();

            // Assert
            result.Should().BeNull();
        }

    }
}
