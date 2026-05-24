using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity GetByIdWithActivities(int entityId, int editionId = default);
    }
}
