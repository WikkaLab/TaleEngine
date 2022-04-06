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
    public class ActivityStatusMapperTests
    {
        [Fact]
        public void ActivityStatus_EntityToDto()
        {
            // Arrange
            ActivityStatusEntity entity = ActivityBuilder.BuildActivityStatus();

            // Act
            ActivityStatusDto result = ActivityStatusMapper.Map(entity);

            // Assert
            result.Id.Should().Be(entity.Id);
            result.Name.Should().Be(entity.Name);
        }
    }
}
