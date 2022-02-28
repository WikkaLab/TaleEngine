using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface IEditionRepository : IGenericRepository<EditionEntity>
    {
        EditionEntity GetLastEditionInEvent(int ofEvent);
        List<EditionEntity> GetEditions(int ofEvent);
    }
}
