using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.Commands.Contracts

{
    public interface IEditionCommands
    {
        EditionDaysDto EditionDaysQuery(int editionId);
        int FutureOrCurrentEditionQuery(int ofEvent);

    }
}
