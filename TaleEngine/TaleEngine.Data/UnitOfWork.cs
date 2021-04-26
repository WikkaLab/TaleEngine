using System;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Repositories;

namespace TaleEngine.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _context;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));

            EventRepository = new EventRepository(_context);
            EditionRepository = new EditionRepository(_context);
            ActivityRepository = new ActivityRepository(_context);
            ActivityStatusRepository = new ActivityStatusRepository(_context);
            ActivityTypeRepository = new ActivityTypeRepository(_context);
            TimeSlotRepository = new TimeSlotRepository(_context);
            RoleRepository = new RoleRepository(_context);
        }

        public IEventRepository EventRepository { get; }
        public IActivityRepository ActivityRepository { get; set; }
        public IActivityStatusRepository ActivityStatusRepository { get; set; }
        public IActivityTypeRepository ActivityTypeRepository { get; set; }
        public IEditionRepository EditionRepository { get; set; }
        public ITimeSlotRepository TimeSlotRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
    }
}
