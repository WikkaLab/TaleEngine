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
    public class EditionQueriesTests
    {
        private readonly Mock<IEditionService> _editionServiceMock;

        public EditionQueriesTests()
        {
            _editionServiceMock = new Mock<IEditionService>();
        }

        [Fact]
        public void EditionDaysQuery_WhenEditionDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            const int editionId = 14;
            _editionServiceMock.Setup(x => x.GetById(editionId)).Returns((EditionEntity)null);
            var target = BuildTarget();

            // Act
            var result = target.EditionDaysQuery(editionId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void EditionDaysQuery_WhenEditionExists_ShouldReturnAllDaysInRangeInclusive()
        {
            // Arrange
            const int editionId = 14;
            var init = new DateTime(2026, 06, 20);
            var end = new DateTime(2026, 06, 23);

            _editionServiceMock.Setup(x => x.GetById(editionId)).Returns(new EditionEntity
            {
                Id = editionId,
                DateInit = init,
                DateEnd = end
            });

            var target = BuildTarget();

            // Act
            var result = target.EditionDaysQuery(editionId);

            // Assert
            result.Should().NotBeNull();
            result.EditionDays.Should().HaveCount(4);
            result.EditionDays[0].Date.Should().Be(init.Date);
            result.EditionDays[3].Date.Should().Be(end.Date);
        }

        [Fact]
        public void EditionsQuery_WhenEventIdIsZero_ShouldReturnNull()
        {
            // Arrange
            var target = BuildTarget();

            // Act
            var result = target.EditionsQuery(0);

            // Assert
            result.Should().BeNull();
            _editionServiceMock.Verify(x => x.GetEditions(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void EditionsQuery_WhenServiceReturnsNullOrEmpty_ShouldReturnNull()
        {
            // Arrange
            const int eventId = 2;
            var target = BuildTarget();

            _editionServiceMock.Setup(x => x.GetEditions(eventId)).Returns((List<EditionEntity>)null);
            var nullResult = target.EditionsQuery(eventId);

            _editionServiceMock.Setup(x => x.GetEditions(eventId)).Returns(new List<EditionEntity>());
            var emptyResult = target.EditionsQuery(eventId);

            // Assert
            nullResult.Should().BeNull();
            emptyResult.Should().BeNull();
        }

        [Fact]
        public void EditionsQuery_WhenServiceReturnsItems_ShouldMapAndReturnDtos()
        {
            // Arrange
            const int eventId = 5;
            _editionServiceMock.Setup(x => x.GetEditions(eventId)).Returns(new List<EditionEntity>
            {
                new EditionEntity { Id = 1, EventId = eventId },
                new EditionEntity { Id = 2, EventId = eventId }
            });
            var target = BuildTarget();

            // Act
            var result = target.EditionsQuery(eventId);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Id.Should().Be(1);
            result[0].EventId.Should().Be(eventId);
        }

        [Fact]
        public void FutureOrCurrentEditionQuery_WhenEventIdIsZero_ShouldReturnZero()
        {
            // Arrange
            var target = BuildTarget();

            // Act
            var result = target.FutureOrCurrentEditionQuery(0);

            // Assert
            result.Should().Be(0);
            _editionServiceMock.Verify(x => x.GetEditions(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void FutureOrCurrentEditionQuery_WhenNoEditionsExist_ShouldReturnZero()
        {
            // Arrange
            const int eventId = 4;
            _editionServiceMock.Setup(x => x.GetEditions(eventId)).Returns(new List<EditionEntity>());
            var target = BuildTarget();

            // Act
            var result = target.FutureOrCurrentEditionQuery(eventId);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void FutureOrCurrentEditionQuery_WhenFutureEditionExists_ShouldReturnFutureEditionId()
        {
            // Arrange
            const int eventId = 4;
            _editionServiceMock.Setup(x => x.GetEditions(eventId)).Returns(new List<EditionEntity>
            {
                new EditionEntity { Id = 1, DateInit = DateTime.Today.AddDays(-1) },
                new EditionEntity { Id = 2, DateInit = DateTime.Today.AddDays(3) }
            });
            var target = BuildTarget();

            // Act
            var result = target.FutureOrCurrentEditionQuery(eventId);

            // Assert
            result.Should().Be(2);
            _editionServiceMock.Verify(x => x.GetLastEditionInEvent(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void FutureOrCurrentEditionQuery_WhenNoFutureEdition_ShouldFallbackToLastEdition()
        {
            // Arrange
            const int eventId = 4;
            _editionServiceMock.Setup(x => x.GetEditions(eventId)).Returns(new List<EditionEntity>
            {
                new EditionEntity { Id = 1, DateInit = DateTime.Today.AddDays(-10) },
                new EditionEntity { Id = 2, DateInit = DateTime.Today.AddDays(-2) }
            });
            _editionServiceMock.Setup(x => x.GetLastEditionInEvent(eventId)).Returns(new EditionEntity { Id = 88 });
            var target = BuildTarget();

            // Act
            var result = target.FutureOrCurrentEditionQuery(eventId);

            // Assert
            result.Should().Be(88);
            _editionServiceMock.Verify(x => x.GetLastEditionInEvent(eventId), Times.Once);
        }

        [Fact]
        public void FutureOrCurrentEditionQuery_WhenFallbackReturnsNull_ShouldReturnZero()
        {
            // Arrange
            const int eventId = 4;
            _editionServiceMock.Setup(x => x.GetEditions(eventId)).Returns(new List<EditionEntity>
            {
                new EditionEntity { Id = 1, DateInit = DateTime.Today.AddDays(-10) }
            });
            _editionServiceMock.Setup(x => x.GetLastEditionInEvent(eventId)).Returns((EditionEntity)null);
            var target = BuildTarget();

            // Act
            var result = target.FutureOrCurrentEditionQuery(eventId);

            // Assert
            result.Should().Be(0);
        }

        private EditionQueries BuildTarget()
        {
            return new EditionQueries(_editionServiceMock.Object);
        }
    }
}
