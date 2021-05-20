using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class RoleServiceTests
    {
        private Mock<IRoleDomainService> serviceMock;

        public RoleServiceTests()
        {
            serviceMock = new Mock<IRoleDomainService>();
        }

        [Fact]
        public void GetRoles_Success()
        {
            // Arrange
            List<RoleModel> list = RoleModelBuilder.BuildRoleModelList();

            serviceMock.Setup(x => x.GetAllRoles())
                .Returns(list);

            RoleService service = new RoleService(serviceMock.Object);

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
            List<RoleModel> list = new();

            serviceMock.Setup(x => x.GetAllRoles())
                .Returns(list);

            RoleService service = new RoleService(serviceMock.Object);

            // Act
            var result = service.GetAllRoles();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetRoles_ReturnsNull_Success()
        {
            // Arrange
            List<RoleModel> list = null;

            serviceMock.Setup(x => x.GetAllRoles())
                .Returns(list);

            RoleService service = new RoleService(serviceMock.Object);

            // Act
            var result = service.GetAllRoles();

            // Assert
            result.Should().BeNull();
        }
    }
}
