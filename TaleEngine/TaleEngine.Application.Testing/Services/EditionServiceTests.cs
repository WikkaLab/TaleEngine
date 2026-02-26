using Moq;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using Xunit;

namespace TaleEngine.Services.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class EditionServiceTests
    {
        private Mock<IUnitOfWork> mock;

        public EditionServiceTests()
        {
            mock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void Method_Success()
        {
            // Arrange
            int editionId = 0;
            EditionEntity model = null;
            //mock.Setup(x => x.EditionRepository.???)
            //    .Returns(???);

            EditionService target = new EditionService(mock.Object);

            // Act
            //Assert.;

            // Asert
            //mock.Verify(???, Times.Never);
        }
    }
}
