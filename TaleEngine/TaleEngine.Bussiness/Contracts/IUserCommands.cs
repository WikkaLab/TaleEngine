namespace TaleEngine.CQRS.Contracts
{
    public interface IUserCommands
    {
        void ActivateCommand(int userId);
        void DeactivateCommand(int userId);
        void BanCommand(int userId);
        void ReviewCommand(int userId);
        void MarkAsPendingCommand(int userId);
        void AssignRoleCommand(int userId, int roleId);
    }
}
