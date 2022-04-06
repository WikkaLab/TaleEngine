using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Bussiness.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class EditionMapperTests
    {
        [Fact]
        public void Edition_EntityToDto()
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
        public void Edition_EntityToDto_IsNull()
        {
            // Arrange
            EditionEntity entity = null;

            // Act
            var result = EditionMapper.Map(entity);

            // Assert
            result.Should().Be(null);
        }
    }
}
