using FluentAssertions;
using Moq;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class EditionServiceTEsts
    {
        private Mock<IEditionDomainService> serviceMock;

        public EditionServiceTEsts()
        {
            serviceMock = new Mock<IEditionDomainService>();
        }

        [Fact]
        public void GetEditionDays_Success()
        {
            // Arrange
            int editionId = 1;
            var editionDays = EditionModelBuilder.BuildEditionDaysModel();
            serviceMock.Setup(x => x.GetEditionDays(editionId))
                .Returns(editionDays);

            EditionService target = new EditionService(serviceMock.Object);

            // Act
            var result = target.GetEditionDays(editionId);

            // Asert
            result.Should().NotBeNull();
            serviceMock.Verify(x => x.GetEditionDays(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetEditionDays_EditionIdIsZero_ShouldReturnNull()
        {
            // Arrange
            int editionId = 0;
            EditionDaysModel editionDays = null;
            serviceMock.Setup(x => x.GetEditionDays(editionId))
                .Returns(editionDays);

            EditionService target = new EditionService(serviceMock.Object);

            // Act
            var result = target.GetEditionDays(editionId);

            // Asert
            result.Should().BeNull();
            serviceMock.Verify(x => x.GetEditionDays(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetCurrentOrLastEdition_Success()
        {
            // Arrange
            int editionId = 1;
            EditionModel model = EditionModelBuilder.BuildEditionModel();
            serviceMock.Setup(x => x.GetLastOrCurrentEdition(editionId))
                .Returns(model);

            EditionService target = new EditionService(serviceMock.Object);

            // Act
            var result = target.GetCurrentOrLastEdition(editionId);

            // Asert
            serviceMock.Verify(x => x.GetLastOrCurrentEdition(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetCurrentOrLastEdition_EditionIdIsZero_ShouldReturnZero()
        {
            // Arrange
            int editionId = 0;
            EditionModel model = null;
            serviceMock.Setup(x => x.GetLastOrCurrentEdition(editionId))
                .Returns(model);

            EditionService target = new EditionService(serviceMock.Object);

            // Act
            var result = target.GetCurrentOrLastEdition(editionId);

            // Asert
            result.Should().Be(0);
            serviceMock.Verify(x => x.GetLastOrCurrentEdition(It.IsAny<int>()), Times.Once);
        }
    }
}
