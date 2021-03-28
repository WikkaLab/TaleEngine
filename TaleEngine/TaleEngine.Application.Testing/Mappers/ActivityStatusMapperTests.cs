using FluentAssertions;
using TaleEngine.Application.Mappers;
using TaleEngine.Fakes.Dtos;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Mappers
{
    public class ActivityStatusMapperTests
    {
        [Fact]
        public void ActivityStatus_DtoToModel()
        {
            // Arrange
            var dto = ActivityDtoBuilder.BuildActivityStatusDto();

            // Act
            var result = ActivityStatusMapper.Map(dto);

            // Assert
            result.Id.Should().Be(dto.Id);
            result.Name.Should().Be(dto.Name);
        }

        [Fact]
        public void ActivityStatus_ModelToDto()
        {
            // Arrange
            var model = ActivityModelBuilder.BuildActivityStatusDto();

            // Act
            var result = ActivityStatusMapper.Map(model);

            // Assert
            result.Id.Should().Be(model.Id);
            result.Name.Should().Be(model.Name);
        }

    }
}
