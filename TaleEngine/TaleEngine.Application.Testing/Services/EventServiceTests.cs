using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Fakes.Entities;
using TaleEngine.Services;
using Xunit;

namespace TaleEngine.DbServices.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class EventServiceTests
    {
        private Mock<IUnitOfWork> mock;

        public EventServiceTests()
        {
            mock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void GetEvents_Success()
        {
            // Arrange
            List<EventEntity> list = EventBuilder.BuildEventList();

            mock.Setup(x => x.EventRepository.GetAll())
                .Returns(list);

            EventService service = new EventService(mock.Object);

            // Act
            var result = service.GetAllEvents();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetEvents_ReturnsEmpty_Success()
        {
            // Arrange
            List<EventEntity> list = new();

            mock.Setup(x => x.EventRepository.GetAll())
                .Returns(list);

            EventService service = new EventService(mock.Object);

            // Act
            var result = service.GetAllEvents();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void GetEvents_ReturnsNull_Success()
        {
            // Arrange
            List<EventEntity> list = null;

            mock.Setup(x => x.EventRepository.GetAll())
                .Returns(list);

            EventService service = new EventService(mock.Object);

            // Act
            var result = service.GetAllEvents();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetEvent_Success()
        {
            // Arrange
            int eventId = 1;
            EventEntity model = EventBuilder.BuildEvent();

            mock.Setup(x => x.EventRepository.GetById(eventId))
                .Returns(model);

            EventService service = new EventService(mock.Object);

            // Act
            var result = service.GetById(eventId);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void GetEvent_EditionIdIsZero_Success()
        {
            // Arrange
            int eventId = 0;
            EventEntity model = EventBuilder.BuildEvent();

            mock.Setup(x => x.EventRepository.GetById(eventId))
                .Returns(model);

            EventService service = new EventService(mock.Object);

            // Act
            var result = service.GetById(eventId);

            // Assert
            result.Should().NotBeNull();
        }

    }
}
