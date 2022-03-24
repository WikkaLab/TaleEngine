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
    public class RoleMapperTests
    {
        [Fact]
        public void Role_EntityToDto()
        {
            // Arrange
            RoleEntity entity = RoleBuilder.BuildRole();

            // Act
            RoleDto result = RoleMapper.Map(entity);

            // Assert
            result.Id.Should().Be(entity.Id);
            result.Name.Should().Be(entity.Name);
        }

        [Fact]
        public void Role_EntityToDto_IsNull()
        {
            // Arrange
            RoleEntity entity = null;

            // Act
            RoleDto result = RoleMapper.Map(entity);

            // Assert
            result.Should().Be(null);
        }
    }
}
