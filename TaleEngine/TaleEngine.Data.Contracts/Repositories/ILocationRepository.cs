using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Contracts.Repositories
{
    public interface ILocationRepository : IGenericRepository<LocationEntity>
    {
        List<LocationEntity> GetByEdition(int editionId);
    }
}
