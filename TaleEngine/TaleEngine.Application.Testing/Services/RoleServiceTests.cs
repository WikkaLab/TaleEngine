using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Services.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class RoleServiceTests
    {
        private Mock<IUnitOfWork> mock;

        public RoleServiceTests()
        {
            mock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void GetRoles_Success()
        {
            // Arrange
            List<RoleEntity> list = RoleBuilder.BuildRoleList();

            mock.Setup(x => x.RoleRepository.GetAll())
                .Returns(list);

            RoleService service = new RoleService(mock.Object);

            // Act
            var result = service.GetAllRoles();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetRoles_ReturnsEmpty_Success()
        {
            // Arrange
            List<RoleEntity> list = new();

            mock.Setup(x => x.RoleRepository.GetAll())
                .Returns(list);

            RoleService service = new RoleService(mock.Object);

            // Act
            var result = service.GetAllRoles();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void GetRoles_ReturnsNull_Success()
        {
            // Arrange
            List<RoleEntity> list = null;

            mock.Setup(x => x.RoleRepository.GetAll())
                .Returns(list);

            RoleService service = new RoleService(mock.Object);

            // Act
            var result = service.GetAllRoles();

            // Assert
            result.Should().BeNull();
        }
    }
}
