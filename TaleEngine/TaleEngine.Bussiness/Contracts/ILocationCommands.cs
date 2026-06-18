using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface ILocationCommands
    {
        void CreateCommand(LocationDto locationDto);
        void UpdateCommand(LocationDto locationDto);
        void DeleteCommand(int locationId);
    }
}
