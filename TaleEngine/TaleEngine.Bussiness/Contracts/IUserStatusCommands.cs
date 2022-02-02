namespace TaleEngine.Commands.Contracts
{
    public interface IUserStatusCommands
    {
        int ActiveQuery();
        int PendingQuery();
        int BanQuery();
        int RevisionQuery();
        int InactiveQuery();
    }
}
