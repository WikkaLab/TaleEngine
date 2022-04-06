using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.CQRS.Impl;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class RoleDomainServiceTests
    {
        private Mock<IRoleService> roleServMock;

        public RoleDomainServiceTests()
        {
            roleServMock = new Mock<IRoleService>();
        }

        [Fact]
        public void GetAll_Success()
        {
            // Arrange
            List<RoleEntity> list = RoleBuilder.BuildRoleList();

            roleServMock.Setup(x => x.GetAllRoles())
                .Returns(list);

            var target = new RoleCommands(roleServMock.Object);

            // Act
            var result = target.AllRolesQuery();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetAll_RepoIsEmpty_ShouldReturnNull()
        {
            // Arrange
            List<RoleEntity> list = null;

            roleServMock.Setup(x => x.GetAllRoles())
                .Returns(list);

            var target = new RoleCommands(roleServMock.Object);

            // Act
            var result = target.AllRolesQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetAll_EmptyResult_ShouldReturnNull()
        {
            // Arrange
            List<RoleEntity> list = new();

            roleServMock.Setup(x => x.GetAllRoles())
                .Returns(list);

            var target = new RoleCommands(roleServMock.Object);

            // Act
            var result = target.AllRolesQuery();

            // Assert
            result.Should().BeNull();
        }
    }
}

