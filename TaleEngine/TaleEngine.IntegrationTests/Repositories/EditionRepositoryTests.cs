using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TaleEngine.Data.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.IntegrationTests.Repositories
{
    [ExcludeFromCodeCoverage]
    public class EditionRepositoryTests : TaleEngineContextInMemoryDatabase
    {
        private EditionRepository CreateEditionRepository()
        {
            return new EditionRepository(_dbContext);
        }

        [Fact]
        public void InsertEdition_Success()
        {
            var repository = CreateEditionRepository();
            var entity = EditionBuilder.BuildEdition();

            repository.Insert(entity);
            repository.Save();

            var newItem = repository.GetAll().FirstOrDefault();

            Assert.Equal(entity, newItem);
            Assert.True(newItem?.Id > 0);
        }

        [Fact]
        public void DeleteEditionAfterAddingIt()
        {
            // add an item
            var repository = CreateEditionRepository();
            var item = EditionBuilder.BuildEdition();
            var initialId = item.Id;

            repository.Insert(item);

            // delete the item
            repository.Delete(item.Id);

            // verify it's no longer there
            Assert.DoesNotContain(repository.GetAll(), i => i.Id == initialId);
        }
    }
}