using System;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _context;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public IEventRepository EventRepository { get; set; }
        public IActivityRepository ActitivyRepository { get; set; }
        public IActivityStatusRepository ActivityStatusRepository { get; set; }
        public IActivityTypeRepository ActivityTypeRepository { get; set; }
    }
}
