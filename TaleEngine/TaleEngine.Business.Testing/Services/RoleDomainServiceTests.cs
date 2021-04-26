using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Business.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class RoleDomainServiceTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<IRoleRepository> roleRepoMock;

        public RoleDomainServiceTests()
        {
            uowMock = new Mock<IUnitOfWork>();
            roleRepoMock = new Mock<IRoleRepository>();
        }

        [Fact]
        public void GetAll_Success()
        {
            // Arrange
            List<Role> list = RoleBuilder.BuildRoleList();

            roleRepoMock.Setup(x => x.GetAll())
                .Returns(list);
            uowMock.Setup(x => x.RoleRepository)
                .Returns(roleRepoMock.Object);
            var target = new RoleDomainService(uowMock.Object);

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

            roleRepoMock.Setup(x => x.GetAll())
                .Returns(list);
            uowMock.Setup(x => x.RoleRepository)
                .Returns(roleRepoMock.Object);
            var target = new RoleDomainService(uowMock.Object);

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

            roleRepoMock.Setup(x => x.GetAll())
                .Returns(list);
            uowMock.Setup(x => x.RoleRepository)
                .Returns(roleRepoMock.Object);
            var target = new RoleDomainService(uowMock.Object);

            // Act
            var result = target.GetAllRoles();

            // Assert
            result.Should().BeNull();
        }
    }
}

