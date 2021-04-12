using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Fakes.Entities;
using TaleEngine.Fakes.Models;
using Xunit;
using TaleEngine.Data.Contracts.Entities;

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
            Edition entity = null;

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
