using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface ILocationService
    {
        LocationEntity GetById(int id);
        List<LocationEntity> GetByEdition(int editionId);
        void CreateLocation(LocationEntity location);
        void UpdateLocation(LocationEntity location);
        void DeleteLocation(int id);
    }
}
