using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Fakes.Dtos;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Bussiness.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class ActivityMapperTests
    {
        [Fact]
        public void Activity_EntityToDto()
        {
            // Arrange
            ActivityEntity entity = ActivityBuilder.BuildActivity();

            // Act
            ActivityDto result = ActivityMapper.MapEntityToDto(entity);

            // Assert
            result.Id.Should().Be(entity.Id);
            result.Title.Should().Be(entity.Title);
            result.Description.Should().Be(entity.Description);
            result.Places.Should().Be(entity.Places);
            result.Image.Should().Be(entity.Image);
            result.StatusId.Should().Be(entity.StatusId);
            result.TimeSlotId.Should().Be(entity.TimeSlotId);
            result.TypeId.Should().Be(entity.TypeId);
        }

        [Fact]
        public void Activity_DtoToModel()
        {
            // Arrange
            ActivityDto dto = ActivityDtoBuilder.BuildActivityDto();

            // Act
            Activity result = ActivityMapper.MapDtoToModel(dto);

            // Assert
            result.Title.Should().Be(dto.Title);
            result.Description.Should().Be(dto.Description);
            result.Places.Should().Be(dto.Places);
            result.Image.Should().Be(dto.Image);
            result.Status.Should().Be(dto.StatusId);
            result.TimeSlot.Should().Be(dto.TimeSlotId);
            result.Type.Should().Be(dto.TypeId);
        }

        [Fact]
        public void Activity_EntityToModel()
        {
            // Arrange
            ActivityEntity entity = ActivityBuilder.BuildActivity();

            // Act
            Activity result = ActivityMapper.MapEntityToModel(entity);

            // Assert
            result.Title.Should().Be(entity.Title);
            result.Description.Should().Be(entity.Description);
            result.Places.Should().Be(entity.Places);
            result.Image.Should().Be(entity.Image);
            result.Status.Should().Be(entity.StatusId);
            result.TimeSlot.Should().Be(entity.TimeSlotId);
            result.Type.Should().Be(entity.TypeId);
        }

    }
}
