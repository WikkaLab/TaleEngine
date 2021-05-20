using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Mappers;
using TaleEngine.Fakes.Dtos;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class EventMapperTests
    {
        [Fact]
        public void Event_DtoToModel()
        {
            // Arrange
            var dto = EventDtoBuilder.BuildEventDto();

            // Act
            var result = EventMapper.Map(dto);

            // Assert
            result.Title.Should().Be(dto.Title);
        }

        [Fact]
        public void Event_ModelToDto()
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
