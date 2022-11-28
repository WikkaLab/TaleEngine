using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IEditionQueries
    {
        EditionDaysDto EditionDaysQuery(int editionId);
        int FutureOrCurrentEditionQuery(int ofEvent);
    }
}
