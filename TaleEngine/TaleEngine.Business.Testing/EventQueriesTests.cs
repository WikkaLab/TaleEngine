using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using TaleEngine.CQRS.Queries;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class EventQueriesTests
    {
        private readonly Mock<IEventService> _serviceMock;

        public EventQueriesTests()
        {
            _serviceMock = new Mock<IEventService>();
        }

        [Fact]
        public void EventsNoFilterQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllEvents()).Returns(new List<EventEntity>
            {
                new EventEntity { Id = 1, Title = "Conf A" },
                new EventEntity { Id = 2, Title = "Conf B" }
            });
            var target = new EventQueries(_serviceMock.Object);

            // Act
            var result = target.EventsNoFilterQuery();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Id.Should().Be(1);
            result[1].Title.Should().Be("Conf B");
        }

        [Fact]
        public void EventsNoFilterQuery_WhenServiceReturnsEmpty_ShouldReturnEmptyList()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllEvents()).Returns(new List<EventEntity>());
            var target = new EventQueries(_serviceMock.Object);

            // Act
            var result = target.EventsNoFilterQuery();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void EventsNoFilterQuery_WhenServiceReturnsNull_ShouldThrow()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllEvents()).Returns((List<EventEntity>)null);
            var target = new EventQueries(_serviceMock.Object);

            // Act
            Action act = () => target.EventsNoFilterQuery();

            // Assert
            act.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void GetEvent_WhenEntityExists_ShouldReturnMappedDto()
        {
            // Arrange
            const int eventId = 10;
            _serviceMock.Setup(x => x.GetById(eventId)).Returns(new EventEntity { Id = eventId, Title = "Main Event" });
            var target = new EventQueries(_serviceMock.Object);

            // Act
            var result = target.GetEvent(eventId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(eventId);
            result.Title.Should().Be("Main Event");
        }

        [Fact]
        public void GetEvent_WhenEntityDoesNotExist_ShouldThrow()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns((EventEntity)null);
            var target = new EventQueries(_serviceMock.Object);

            // Act
            Action act = () => target.GetEvent(4);

            // Assert
            act.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void GetCurrentEdition_WhenEntityExists_ShouldReturnMappedDto()
        {
            // Arrange
            const int eventId = 20;
            _serviceMock.Setup(x => x.GetById(eventId)).Returns(new EventEntity
            {
                Id = eventId,
                Title = "Annual",
                CurrentEditionId = 77
            });
            var target = new EventQueries(_serviceMock.Object);

            // Act
            var result = target.GetCurrentEdition(eventId);

            // Assert
            result.Should().NotBeNull();
            result.EventId.Should().Be(eventId);
            result.EventTitle.Should().Be("Annual");
            result.EditionId.Should().Be(77);
        }

        [Fact]
        public void GetCurrentEdition_WhenEntityDoesNotExist_ShouldThrow()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns((EventEntity)null);
            var target = new EventQueries(_serviceMock.Object);

            // Act
            Action act = () => target.GetCurrentEdition(3);

            // Assert
            act.Should().Throw<NullReferenceException>();
        }
    }
}
