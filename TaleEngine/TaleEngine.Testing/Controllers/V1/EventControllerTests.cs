using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Controllers.V1;
using TaleEngine.CQRS.Contracts;
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

            Mock<IEventQueries> serviceMock = new Mock<IEventQueries>();
            serviceMock.Setup(x => x.EventsNoFilterQuery())
                .Returns(dto);

            EventController target = new EventController(serviceMock.Object);

            // Act
            var result = target.GetEvents();

            // Assert
            ObjectResult resultAsObjResult = result as ObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.EventsNoFilterQuery(), Times.Once);
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

            Mock<IEventQueries> serviceMock = new Mock<IEventQueries>();
            serviceMock.Setup(x => x.EventQuery(eventId))
                .Returns(dto);

            EventController target = new EventController(serviceMock.Object);

            // Act
            var result = target.GetEvent(eventId);

            // Assert
            ObjectResult resultAsObjResult = result as ObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.EventQuery(eventId), Times.Once);
        }
    }
}
