using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class EventServiceTests
    {
        private Mock<IEventDomainService> eventServiceMock;
        private Mock<IEditionService> editionServiceMock;

        public EventServiceTests()
        {
            eventServiceMock = new Mock<IEventDomainService>();
            editionServiceMock = new Mock<IEditionService>();
        }

        [Fact]
        public void GetEvents_Success()
        {
            // Arrange
            List<EventModel> list = EventModelBuilder.BuildEventModelList();

            eventServiceMock.Setup(x => x.GetEventsNoFilter())
                .Returns(list);

            EventService service = new EventService(
                eventServiceMock.Object, editionServiceMock.Object);

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
            List<EventModel> list = new();

            eventServiceMock.Setup(x => x.GetEventsNoFilter())
                .Returns(list);

            EventService service = new EventService(
                eventServiceMock.Object, editionServiceMock.Object);

            // Act
            var result = service.GetAllEvents();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetEvents_ReturnsNull_Success()
        {
            // Arrange
            List<EventModel> list = null;

            eventServiceMock.Setup(x => x.GetEventsNoFilter())
                .Returns(list);

            EventService service = new EventService(
                eventServiceMock.Object, editionServiceMock.Object);

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
            EventModel model = EventModelBuilder.BuildEventModel();

            eventServiceMock.Setup(x => x.GetEvent(eventId))
                .Returns(model);

            EventService service = new EventService(
                eventServiceMock.Object, editionServiceMock.Object);

            // Act
            var result = service.GetEvent(eventId);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void GetEvent_EditionIdIsZero_Success()
        {
            // Arrange
            int eventId = 0;
            EventModel model = EventModelBuilder.BuildEventModel();

            eventServiceMock.Setup(x => x.GetEvent(eventId))
                .Returns(model);

            EventService service = new EventService(
                eventServiceMock.Object, editionServiceMock.Object);

            // Act
            var result = service.GetEvent(eventId);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void GetCurrentOrLastEdition_Success()
        {
            // Arrange
            int eventId = 1;
            int resultId = 2;

            editionServiceMock.Setup(x => x.GetCurrentOrLastEdition(eventId))
                .Returns(resultId);

            EventService service = new EventService(
                eventServiceMock.Object, editionServiceMock.Object);

            // Act
            var result = service.GetCurrentOrLastEdition(eventId);

            // Assert
            result.Should().NotBe(0);
        }

        [Fact]
        public void GetCurrentOrLastEdition_EditionIdIsZero_Success()
        {
            // Arrange
            int eventId = 0;
            int resultId = 0;

            editionServiceMock.Setup(x => x.GetCurrentOrLastEdition(eventId))
                .Returns(resultId);

            EventService service = new EventService(
                eventServiceMock.Object, editionServiceMock.Object);

            // Act
            var result = service.GetCurrentOrLastEdition(eventId);

            // Assert
            result.Should().Be(0);
        }

    }
}
