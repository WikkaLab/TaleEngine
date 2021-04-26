using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface IEditionRepository : IGenericRepository<Edition>
    {
        Edition GetLastEditionInEvent(int ofEvent);
    }
}
