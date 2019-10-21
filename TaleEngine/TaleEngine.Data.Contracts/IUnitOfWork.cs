using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Contracts
{
    public interface IUnitOfWork
    {
        IEventRepository EventRepository { get; }
        IActivityRepository ActivityRepository { get; }
        IActivityStatusRepository ActivityStatusRepository { get; }
        IActivityTypeRepository ActivityTypeRepository { get; }
        IEditionRepository EditionRepository { get; }
    }
}
