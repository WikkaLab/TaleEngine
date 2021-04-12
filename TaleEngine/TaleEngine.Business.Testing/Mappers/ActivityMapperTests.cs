using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Fakes.Entities;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Bussiness.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class ActivityMapperTests
    {
        [Fact]
        public void Activity_EntityToModel()
        {
            // Arrange
            var entity = ActivityBuilder.BuildActivity();

            // Act
            var result = ActivityMapper.Map(entity);

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
        public void Activity_ModelToEntity()
        {
            // Arrange
            var model = ActivityModelBuilder.BuildActivityModel();

            // Act
            var result = ActivityMapper.Map(model);

            // Assert
            result.Id.Should().Be(model.Id);
            result.Title.Should().Be(model.Title);
            result.Description.Should().Be(model.Description);
            result.Places.Should().Be(model.Places);
            result.Image.Should().Be(model.Image);
            result.StatusId.Should().Be(model.StatusId);
            result.TimeSlotId.Should().Be(model.TimeSlotId);
            result.TypeId.Should().Be(model.TypeId);
        }

    }
}
