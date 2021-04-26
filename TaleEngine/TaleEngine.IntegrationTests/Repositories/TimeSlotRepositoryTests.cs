using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TaleEngine.Data.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.IntegrationTests.Repositories
{
    [ExcludeFromCodeCoverage]
    public class TimeSlotRepositoryTests : TaleEngineContextInMemoryDatabase
    {
        private TimeSlotRepository CreateTimeSlotRepository()
        {
            return new TimeSlotRepository(_dbContext);
        }

        [Fact]
        public void InsertTimeSlot_Success()
        {
            var repository = CreateTimeSlotRepository();
            var entity = TimeSlotBuilder.BuildTimeSlot();

            repository.Insert(entity);
            repository.Save();

            var newItem = repository.GetAll().FirstOrDefault();

            Assert.Equal(entity, newItem);
            Assert.True(newItem?.Id > 0);
        }

        [Fact]
        public void DeleteTimeSlotAfterAddingIt()
        {
            // add an item
            var repository = CreateTimeSlotRepository();
            var item = TimeSlotBuilder.BuildTimeSlot();
            var initialId = item.Id;

            repository.Insert(item);

            // delete the item
            repository.Delete(item.Id);

            // verify it's no longer there
            Assert.DoesNotContain(repository.GetAll(), i => i.Id == initialId);
        }
    }
}