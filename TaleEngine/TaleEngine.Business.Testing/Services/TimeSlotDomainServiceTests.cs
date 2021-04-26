using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Business.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class TimeSlotDomainServiceTests
    {
        private readonly Mock<ITimeSlotRepository> _timeSlotRepository;

        public TimeSlotDomainServiceTests()
        {
            _timeSlotRepository = new Mock<ITimeSlotRepository>();
        }

        private TimeSlotDomainService CreateTimeSlotDomainService()
        {
            return new TimeSlotDomainService(
                _timeSlotRepository.Object);
        }

        [Fact]
        public void GetActiveActivities_Success()
        {
            // Arrange
            List<TimeSlot> list = TimeSlotBuilder.BuildTimeSlotList();

            _timeSlotRepository.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateTimeSlotDomainService();

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
            List<TimeSlot> list = null;

            _timeSlotRepository.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateTimeSlotDomainService();

            // Act
            var result = target.GetAllTimeSlots();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetActiveActivities_EmptyResult_ShouldReturnNull()
        {
            // Arrange
            List<TimeSlot> list = new();

            _timeSlotRepository.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateTimeSlotDomainService();

            // Act
            var result = target.GetAllTimeSlots();

            // Assert
            result.Should().BeNull();
        }
    }
}