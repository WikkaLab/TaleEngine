using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IPermissionValueCommands
    {
        void CreateCommand(PermissionValueDto permissionValueDto);
        void UpdateCommand(PermissionValueDto permissionValueDto);
        void DeleteCommand(int permissionValueId);
    }
}
