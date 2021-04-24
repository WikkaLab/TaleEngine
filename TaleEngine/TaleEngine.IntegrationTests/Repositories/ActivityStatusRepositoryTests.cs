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
    public class ActivityStatusRepositoryTests : TaleEngineContextInMemoryDatabase
    {
        private ActivityStatusRepository CreateActivityStatusRepository()
        {
            return new ActivityStatusRepository(_dbContext);
        }

        [Fact]
        public void InsertActivityStatus_Success()
        {
            var repository = CreateActivityStatusRepository();
            var entity = ActivityBuilder.BuildActivityStatus();

            repository.Insert(entity);
            repository.Save();

            var newItem = repository.GetAll().FirstOrDefault();

            Assert.Equal(entity, newItem);
            Assert.True(newItem?.Id > 0);
        }

        [Fact]
        public void DeleteActivityStatusAfterAddingIt()
        {
            // add an item
            var repository = CreateActivityStatusRepository();
            var initialName = Guid.NewGuid().ToString();
            var item = ActivityBuilder.BuildActivityStatus();
            item.Name = initialName;
            repository.Insert(item);

            // delete the item
            repository.Delete(item.Id);

            // verify it's no longer there
            Assert.DoesNotContain(repository.GetAll(), i => i.Name == initialName);
        }

        [Fact]
        public void UpdateActivityStatusAfterAddingIt()
        {
            // add an item
            var repository = CreateActivityStatusRepository();
            var item = ActivityBuilder.BuildActivityStatus();
            var initialDescription = item.Description;

            repository.Insert(item);

            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = repository.GetAll().FirstOrDefault(i => i.Description == initialDescription);
            Assert.NotNull(newItem);
            Assert.NotSame(item, newItem);
            var newDescription = Guid.NewGuid().ToString();
            newItem.Description = newDescription;

            // Update the item
            repository.Update(newItem);
            var updatedItem = repository.GetAll().FirstOrDefault(i => i.Description == newDescription);

            Assert.NotNull(updatedItem);
            Assert.NotEqual(item.Description, updatedItem.Description);
            Assert.Equal(newItem.Id, updatedItem.Id);
        }
    }
}