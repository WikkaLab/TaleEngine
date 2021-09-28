using FluentAssertions;
using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class EditionServiceTests
    {
        private Mock<IEditionDomainService> serviceMock;

        public EditionServiceTests()
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
        public void GetCurrentOrFutureEdition_Success()
        {
            // Arrange
            int editionId = 1;
            EditionModel model = EditionModelBuilder.BuildEditionModel();
            serviceMock.Setup(x => x.GetFutureOrCurrentEdition(editionId))
                .Returns(model);

            EditionService target = new EditionService(serviceMock.Object);

            // Act
            var result = target.GetCurrentOrLastEdition(editionId);

            // Asert
            serviceMock.Verify(x => x.GetFutureOrCurrentEdition(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetCurrentOrFutureEdition_EditionIdIsZero_ShouldReturnZero()
        {
            // Arrange
            int editionId = 0;
            EditionModel model = null;
            serviceMock.Setup(x => x.GetFutureOrCurrentEdition(editionId))
                .Returns(model);

            EditionService target = new EditionService(serviceMock.Object);

            // Act
            Assert.Throws<ArgumentNullException>(()
                => target.GetCurrentOrLastEdition(editionId));

            // Asert
            serviceMock.Verify(x => x.GetFutureOrCurrentEdition(It.IsAny<int>()), Times.Never);
        }
    }
}
