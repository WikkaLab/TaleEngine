using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface ILocationQueries
    {
        LocationDto GetLocationQuery(int locationId);
        List<LocationDto> LocationsByEditionQuery(int editionId);
    }
}
