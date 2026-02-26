using TaleEngine.API.Contracts.Dtos.Requests;

namespace TaleEngine.CQRS.Contracts
{
    public interface IAssignedPermissionCommands
    {
        void AssignPermissionCommand(AssignPermissionRequest request);
        void RemovePermissionCommand(AssignPermissionRequest request);
    }
}
