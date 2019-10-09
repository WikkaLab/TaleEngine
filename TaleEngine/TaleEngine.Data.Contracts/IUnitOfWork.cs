using System;
using System.Collections.Generic;
using System.Text;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Contracts
{
    public interface IUnitOfWork
    {
        IEventRepository EventRepository { get; }
        IActivityRepository ActitivyRepository { get; }
        IActivityStatusRepository ActivityStatusRepository { get; }
        IActivityTypeRepository ActivityTypeRepository { get; }
    }
}
