using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TaleEngine.Data.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.IntegrationTests.Repositories
{
    [ExcludeFromCodeCoverage]
    public class ActivityRepositoryTests : DatabaseContextInMemoryDatabase
    {
        private ActivityRepository CreateActivityRepository()
        {
            return new ActivityRepository(_dbContext);
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

        [Fact]
        public void DeleteActivityAfterAddingIt()
        {
            // add an item
            var repository = CreateActivityRepository();
            var initialTitle = Guid.NewGuid().ToString();
            var item = ActivityBuilder.BuildActivity();
            item.Title = initialTitle;
            repository.Insert(item);
            repository.Save();

            // delete the item
            repository.Delete(item.Id);
            repository.Save();

            // verify it's no longer there
            Assert.DoesNotContain(repository.GetAll(), i => i.Title == initialTitle);
        }

        [Fact]
        public void UpdateActivityAfterAddingIt()
        {
            // add an item
            var repository = CreateActivityRepository();
            var initialTitle = Guid.NewGuid().ToString();
            var item = ActivityBuilder.BuildActivity();
            item.Title = initialTitle;

            repository.Insert(item);
            repository.Save();

            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = repository.GetAll().FirstOrDefault(i => i.Title == initialTitle);
            Assert.NotNull(newItem);
            Assert.NotSame(item, newItem);
            var newTitle = Guid.NewGuid().ToString();
            newItem.Title = newTitle;

            // Update the item
            repository.Update(newItem);
            repository.Save();

            var updatedItem = repository.GetAll().FirstOrDefault(i => i.Title == newTitle);

            Assert.NotNull(updatedItem);
            Assert.NotEqual(item.Title, updatedItem.Title);
            Assert.Equal(newItem.Id, updatedItem.Id);
        }
    }
}