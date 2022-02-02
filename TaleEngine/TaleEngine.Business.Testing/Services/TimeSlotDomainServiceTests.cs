using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Business.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class TimeSlotDomainServiceTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITimeSlotRepository> timeSlotRepoMock;

        public TimeSlotDomainServiceTests()
        {
            uowMock = new Mock<IUnitOfWork>();
            timeSlotRepoMock = new Mock<ITimeSlotRepository>();
        }

        [Fact]
        public void GetActiveActivities_Success()
        {
            // Arrange
            List<TimeSlotEntity> list = TimeSlotBuilder.BuildTimeSlotList();

            timeSlotRepoMock.Setup(x => x.GetAll())
                .Returns(list);
            uowMock.Setup(x => x.TimeSlotRepository)
                .Returns(timeSlotRepoMock.Object);
            var target = new TimeSlotCommands(uowMock.Object);

            // Act
            var result = target.GetAllTimeSlots();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetActiveActivities_RepoIsEmpty_ShouldReturnNull()
        {
            // Arrange
            List<TimeSlotEntity> list = null;

            timeSlotRepoMock.Setup(x => x.GetAll())
                .Returns(list);
            uowMock.Setup(x => x.TimeSlotRepository)
                .Returns(timeSlotRepoMock.Object);
            var target = new TimeSlotCommands(uowMock.Object);

            // Act
            var result = target.GetAllTimeSlots();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetActiveActivities_EmptyResult_ShouldReturnNull()
        {
            // Arrange
            List<TimeSlotEntity> list = new();

            timeSlotRepoMock.Setup(x => x.GetAll())
                .Returns(list);
            uowMock.Setup(x => x.TimeSlotRepository)
                .Returns(timeSlotRepoMock.Object);
            var target = new TimeSlotCommands(uowMock.Object);

            // Act
            var result = target.GetAllTimeSlots();

            // Assert
            result.Should().BeNull();
        }
    }
}
