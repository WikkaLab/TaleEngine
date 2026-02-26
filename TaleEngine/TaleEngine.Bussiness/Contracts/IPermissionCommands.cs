using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IPermissionCommands
    {
        void CreateCommand(PermissionDto permissionDto);
        void UpdateCommand(PermissionDto permissionDto);
        void DeleteCommand(int permissionId);
    }
}
