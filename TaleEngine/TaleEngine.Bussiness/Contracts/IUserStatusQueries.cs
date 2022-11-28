namespace TaleEngine.CQRS.Contracts
{
    public interface IUserStatusQueries
    {
        int ActiveQuery();
        int PendingQuery();
        int BanQuery();
        int RevisionQuery();
        int InactiveQuery();
    }
}
