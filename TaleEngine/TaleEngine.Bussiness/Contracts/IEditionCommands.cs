using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IEditionCommands
    {
        EditionDaysDto EditionDaysQuery(int editionId);
        int FutureOrCurrentEditionQuery(int ofEvent);

    }
}
