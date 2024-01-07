using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IEditionQueries
    {
        EditionDaysDto EditionDaysQuery(int editionId);
        List<EditionDto> EditionsQuery(int eventId);
        int FutureOrCurrentEditionQuery(int ofEvent);
    }
}
