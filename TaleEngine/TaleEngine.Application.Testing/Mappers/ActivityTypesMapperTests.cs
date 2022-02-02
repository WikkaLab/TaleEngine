using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Fakes.Dtos;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class ActivityTypesMapperTests
    {
        [Fact]
        public void ActivityType_DtoToModel()
        {
            // Arrange
            var dto = ActivityDtoBuilder.BuildActivityTypeDto();

            // Act
            var result = ActivityTypeMapper.Map(dto);

            // Assert
            result.Id.Should().Be(dto.Id);
            result.Name.Should().Be(dto.Name);
        }

        [Fact]
        public void ActivityType_ModelToDto()
        {
            // Arrange
            var model = ActivityModelBuilder.BuildActivityTypeModel();

            // Act
            var result = ActivityTypeMapper.Map(model);

            // Assert
            result.Id.Should().Be(model.Id);
            result.Name.Should().Be(model.Name);
        }

    }
}
