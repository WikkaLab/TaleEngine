using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.CQRS.Queries;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Fakes.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class TimeSlotDomainServiceTests
    {
        private Mock<ITimeSlotService> timeSlotServMock;

        public TimeSlotDomainServiceTests()
        {
            timeSlotServMock = new Mock<ITimeSlotService>();
        }

        [Fact]
        public void GetActiveActivities_Success()
        {
            // Arrange
            List<TimeSlotEntity> list = TimeSlotBuilder.BuildTimeSlotList();

            timeSlotServMock.Setup(x => x.GetTimeSlots())
                .Returns(list);

            var target = new TimeSlotQueries(timeSlotServMock.Object);

            // Act
            var result = target.AllTimeSlotsQuery();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetActiveActivities_RepoIsEmpty_ShouldReturnNull()
        {
            // Arrange
            List<TimeSlotEntity> list = null;

            timeSlotServMock.Setup(x => x.GetTimeSlots())
                .Returns(list);
            var target = new TimeSlotQueries(timeSlotServMock.Object);

            // Act
            var result = target.AllTimeSlotsQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetActiveActivities_EmptyResult_ShouldReturnNull()
        {
            // Arrange
            List<TimeSlotEntity> list = new();

            timeSlotServMock.Setup(x => x.GetTimeSlots())
                .Returns(list);

            var target = new TimeSlotQueries(timeSlotServMock.Object);

            // Act
            var result = target.AllTimeSlotsQuery();

            // Assert
            result.Should().BeNull();
        }
    }
}
