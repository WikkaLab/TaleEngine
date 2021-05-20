using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class TimeSlotServiceTests
    {
        private Mock<ITimeSlotDomainService> serviceMock;

        public TimeSlotServiceTests()
        {
            serviceMock = new Mock<ITimeSlotDomainService>();
        }

        [Fact]
        public void GetTimeSlots_Success()
        {
            // Arrange
            List<TimeSlotModel> list = TimeSlotModelBuilder.BuildTimeSlotModelList();

            serviceMock.Setup(x => x.GetAllTimeSlots())
                .Returns(list);

            TimeSlotService service = new TimeSlotService(serviceMock.Object);

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
            List<TimeSlotModel> list = new();

            serviceMock.Setup(x => x.GetAllTimeSlots())
                .Returns(list);

            TimeSlotService service = new TimeSlotService(serviceMock.Object);

            // Act
            var result = service.GetTimeSlots();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetTimeSlots_ReturnsNull_Success()
        {
            // Arrange
            List<TimeSlotModel> list = null;

            serviceMock.Setup(x => x.GetAllTimeSlots())
                .Returns(list);

            TimeSlotService service = new TimeSlotService(serviceMock.Object);

            // Act
            var result = service.GetTimeSlots();

            // Assert
            result.Should().BeNull();
        }

    }
}
