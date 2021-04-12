using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Fakes.Entities;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Bussiness.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class EventMapperTests
    {
        [Fact]
        public void Event_EntityToModel()
        {
            // Arrange
            var entity = EventBuilder.BuildEvent();

            // Act
            var result = EventMapper.Map(entity);

            // Assert
            result.Title.Should().Be(entity.Title);
        }

        [Fact]
        public void Event_ModelToEntity()
        {
            // Arrange
            var model = EventModelBuilder.BuildEventModel();

            // Act
            var result = EventMapper.Map(model);

            // Assert
            result.Id.Should().Be(model.Id);
            result.Title.Should().Be(model.Title);
        }

    }
}
