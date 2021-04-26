using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Business.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class RoleDomainServiceTests
    {
        private readonly Mock<IRoleRepository> _roleRepositoryMock;

        public RoleDomainServiceTests()
        {
            _roleRepositoryMock = new Mock<IRoleRepository>();
        }

        private RoleDomainService CreateRoleDomainService()
        {
            return new RoleDomainService(
                _roleRepositoryMock.Object);
        }

        [Fact]
        public void GetAll_Success()
        {
            // Arrange
            List<Role> list = RoleBuilder.BuildRoleList();

            _roleRepositoryMock.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateRoleDomainService();

            // Act
            var result = target.GetAllRoles();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetAll_RepoIsEmpty_ShouldReturnNull()
        {
            // Arrange
            List<Role> list = null;

            _roleRepositoryMock.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateRoleDomainService();

            // Act
            var result = target.GetAllRoles();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetAll_EmptyResult_ShouldReturnNull()
        {
            // Arrange
            List<Role> list = new();

            _roleRepositoryMock.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateRoleDomainService();

            // Act
            var result = target.GetAllRoles();

            // Assert
            result.Should().BeNull();
        }
    }
}