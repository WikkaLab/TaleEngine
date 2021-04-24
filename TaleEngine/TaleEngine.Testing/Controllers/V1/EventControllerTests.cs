using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Controllers.V1;
using Xunit;

namespace TaleEngine.Testing.Controllers.V1
{
    [ExcludeFromCodeCoverage]
    public class EventControllerTests
    {
        [Fact]
        public void GetEvents_Success()
        {
            // Act
            List<EventDto> dto = new()
            {
                new EventDto
                {
                    Id = 1,
                    Title = "Title"
                }
            };

            Mock<IEventService> serviceMock = new Mock<IEventService>();
            serviceMock.Setup(x => x.GetAllEvents())
                .Returns(dto);

            EventController target = new EventController(serviceMock.Object);

            // Act
            var result = target.GetEvents();

            // Assert
            ObjectResult resultAsObjResult = result as ObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.GetAllEvents(), Times.Once);
        }

        [Fact]
        public void GetEvent_Success()
        {
            // Arrange
            int eventId = 1;
            var dto = new EventDto
            {
                Id = 1,
                Title = "Title"
            };

            Mock<IEventService> serviceMock = new Mock<IEventService>();
            serviceMock.Setup(x => x.GetEvent(eventId))
                .Returns(dto);

            EventController target = new EventController(serviceMock.Object);

            // Act
            var result = target.GetEvent(eventId);

            // Assert
            ObjectResult resultAsObjResult = result as ObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.GetEvent(eventId), Times.Once);
        }

        [Fact]
        public void GetCurrentOrLastEdition_Success()
        {
            // Arrange
            int eventId = 1;
            int lastEdition = 2;

            Mock<IEventService> serviceMock = new Mock<IEventService>();
            serviceMock.Setup(x => x.GetCurrentOrLastEdition(eventId))
                .Returns(lastEdition);

            EventController target = new EventController(serviceMock.Object);

            // Act
            var result = target.GetCurrentOrLastEdition(eventId);

            // Assert
            ObjectResult resultAsObjResult = result as ObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.GetCurrentOrLastEdition(eventId), Times.Once);
        }
    }
}