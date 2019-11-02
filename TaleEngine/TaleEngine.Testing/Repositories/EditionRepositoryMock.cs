using Moq;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Testing.Repositories
{
    public class EditionRepositoryMock
    {
        public Mock<IEditionRepository> _editionRepository;

        public EditionRepositoryMock()
        {
            _editionRepository = new Mock<IEditionRepository>();
            Setup();
        }

        private void Setup()
        {
            _editionRepository.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(MockData.GetEdition);
        }
    }
}
