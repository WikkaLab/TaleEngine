using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Bussiness.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class EventMapperTests
    {
        [Fact]
        public void Event_EntityToDto()
        {
            // Arrange
            EventEntity entity = EventBuilder.BuildEvent();

            // Act
            EventDto result = EventMapper.Map(entity);

            // Assert
            result.Id.Should().Be(entity.Id);
            result.Title.Should().Be(entity.Title);
        }
    }
}
