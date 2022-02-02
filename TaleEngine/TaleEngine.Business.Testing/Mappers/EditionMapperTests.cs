using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Fakes.Entities;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Bussiness.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class EditionMapperTests
    {
        [Fact]
        public void Edition_EntityToModel()
        {
            // Arrange
            var entity = EditionBuilder.BuildEdition();

            // Act
            var result = EditionMapper.Map(entity);

            // Assert
            result.Id.Should().Be(entity.Id);
            result.EventId.Should().Be(entity.EventId);
        }

        [Fact]
        public void Edition_EntityToModel_IsNull()
        {
            // Arrange
            EditionEntity entity = null;

            // Act
            var result = EditionMapper.Map(entity);

            // Assert
            result.Should().Be(null);
        }

        [Fact]
        public void Edition_ModelToEntity()
        {
            // Arrange
            var model = EditionModelBuilder.BuildEditionModel();

            // Act
            var result = EditionMapper.Map(model);

            // Assert
            result.EventId.Should().Be(model.EventId);
        }

        [Fact]
        public void Edition_ModelToEntity_IsNull()
        {
            // Arrange
            EditionModel model = null;

            // Act
            var result = EditionMapper.Map(model);

            // Assert
            result.Should().Be(null);
        }

    }
}
