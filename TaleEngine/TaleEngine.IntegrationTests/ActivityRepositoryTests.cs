using System.Linq;
using TaleEngine.Data.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.IntegrationTests
{
    public class ActivityRepositoryTests : DatabaseContextInMemoryDatabase
    {
        private ActivityRepository CreateActivityRepository()
        {
            return new ActivityRepository(_context);
        }

        [Fact]
        public void InsertActivity_Success()
        {
            var repository = CreateActivityRepository();
            var entity = ActivityBuilder.BuildActivity();

            repository.Insert(entity);
            repository.Save();

            var newItem = repository.GetAll().FirstOrDefault();

            Assert.Equal(entity, newItem);
            Assert.True(newItem?.Id > 0);
        }
    }
}