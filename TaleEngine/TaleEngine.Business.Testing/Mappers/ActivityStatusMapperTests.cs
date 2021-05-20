using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Fakes.Entities;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Bussiness.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class ActivityStatusMapperTests
    {
        [Fact]
        public void ActivityStatus_EntityToModel()
        {
            // Arrange
            var entity = ActivityBuilder.BuildActivityStatus();

            // Act
            var result = ActivityStatusMapper.Map(entity);

            // Assert
            result.Id.Should().Be(entity.Id);
            result.Name.Should().Be(entity.Name);
        }

        [Fact]
        public void ActivityStatus_ModelToEntity()
        {
            // Arrange
            var model = ActivityModelBuilder.BuildActivityStatusModel();

            // Act
            var result = ActivityStatusMapper.Map(model);

            // Assert
            result.Id.Should().Be(model.Id);
            result.Name.Should().Be(model.Name);
        }

    }
}
