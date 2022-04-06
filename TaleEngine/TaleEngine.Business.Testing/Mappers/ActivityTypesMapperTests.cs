using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Bussiness.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class ActivityTypesMapperTests
    {
        [Fact]
        public void ActivityType_EntityToDto()
        {
            // Arrange
            ActivityTypeEntity entity = ActivityBuilder.BuildActivityType();

            // Act
            ActivityTypeDto result = ActivityTypeMapper.Map(entity);

            // Assert
            result.Id.Should().Be(entity.Id);
            result.Name.Should().Be(entity.Name);
        }
    }
}
