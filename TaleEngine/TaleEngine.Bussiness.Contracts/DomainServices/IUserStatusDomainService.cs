namespace TaleEngine.Bussiness.Contracts.DomainServices
{
    public interface IUserStatusDomainService
    {
        int GetActiveStatus();
        int GetPendingStatus();
        int GetBanStatus();
        int GetRevisionStatus();
        int GetInactiveStatus();
    }
}
