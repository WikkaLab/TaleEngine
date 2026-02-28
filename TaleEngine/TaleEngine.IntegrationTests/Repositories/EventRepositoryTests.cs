using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TaleEngine.Data.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.IntegrationTests.Repositories
{
    [ExcludeFromCodeCoverage]
    public class EventRepositoryTests : DatabaseContextInMemoryDatabase
    {
        private EventRepository CreateEventRepository()
        {
            return new EventRepository(_dbContext);
        }

        [Fact]
        public void InsertEvent_Success()
        {
            var repository = CreateEventRepository();
            var entity = EventBuilder.BuildEvent();

            repository.Insert(entity);
            repository.Save();

            var newItem = repository.GetAll().FirstOrDefault();

            Assert.Equal(entity, newItem);
            Assert.True(newItem?.Id > 0);
        }

        [Fact]
        public void DeleteEventAfterAddingIt()
        {
            // add an item
            var repository = CreateEventRepository();
            var item = EventBuilder.BuildEvent();
            var initialId = item.Id;

            repository.Insert(item);
            repository.Save();

            // delete the item
            repository.Delete(item.Id);
            repository.Save();

            // verify it's no longer there
            Assert.DoesNotContain(repository.GetAll(), i => i.Id == initialId);
        }
    }
}