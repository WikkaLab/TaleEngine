using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TaleEngine.Data.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.IntegrationTests.Repositories
{
    [ExcludeFromCodeCoverage]
    public class RoleRepositoryTests : DatabaseContextInMemoryDatabase
    {
        private RoleRepository CreateRoleRepository()
        {
            return new RoleRepository(_dbContext);
        }

        [Fact]
        public void InsertRole_Success()
        {
            var repository = CreateRoleRepository();
            var entity = RoleBuilder.BuildRole();

            repository.Insert(entity);
            repository.Save();

            var newItem = repository.GetAll().FirstOrDefault();

            Assert.Equal(entity, newItem);
            Assert.True(newItem?.Id > 0);
        }

        [Fact]
        public void DeleteRoleAfterAddingIt()
        {
            // add an item
            var repository = CreateRoleRepository();
            var item = RoleBuilder.BuildRole();
            var initialId = item.Id;

            repository.Insert(item);

            // delete the item
            repository.Delete(item.Id);

            // verify it's no longer there
            Assert.DoesNotContain(repository.GetAll(), i => i.Id == initialId);
        }
    }
}