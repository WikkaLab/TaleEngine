using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.SeedWork;
using TaleEngine.Data.Data;

namespace TaleEngine.Data
{
    public class TaleEngineContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        private IDbContextTransaction _currentTransaction;

        public TaleEngineContext(DbContextOptions<TaleEngineContext> options) : base(options)
        {
        }

        public TaleEngineContext(DbContextOptions<TaleEngineContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("DatabaseContext::ctor ->" + this.GetHashCode());
        }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json")
                   .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging();
            }
        }

        public override int SaveChanges()
        {
            var modifiedEntites = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            modifiedEntites.ToList().ForEach(x =>
            {
                var entity = x.Entity as BaseEntity;
                entity?.SetAudit(x.State);
            });

            return base.SaveChanges();
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection.
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions.
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers.
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers)
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<ActivityStatus> ActivityStatuses { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionValue> PermissionsValue { get; set; }
        public DbSet<AssignedPermission> AssignedPermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<TimeSlot> TimeSlot { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Event>()
                .ToTable("Event");

            builder.Entity<Edition>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Edition>()
                .HasOne(ed => ed.Event)
                .WithMany(ev => ev.Editions)
                .HasForeignKey(ed => ed.EventId);
            builder.Entity<Edition>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Edition>()
                .ToTable("Edition");

            builder.Entity<Activity>()
                .HasOne(a => a.Edition)
                .WithMany(ed => ed.Activities)
                .HasForeignKey(a => a.EditionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Activity>()
                .HasOne(a => a.TimeSlot)
                .WithMany(tS => tS.Activities)
                .HasForeignKey(a => a.TimeSlotId);
            builder.Entity<Activity>()
                .HasOne(a => a.Status)
                .WithMany(aS => aS.Activities)
                .HasForeignKey(a => a.StatusId);
            builder.Entity<Activity>()
                .HasOne(a => a.Type)
                .WithMany(aT => aT.Activities)
                .HasForeignKey(a => a.TypeId);
            builder.Entity<Activity>()
                .HasMany(a => a.UsersCreate)
                .WithMany(u => u.ActivitiesCreate)
                .UsingEntity(x => x.ToTable("ActivityCreators"));
            builder.Entity<Activity>()
                .HasMany(a => a.UsersFav)
                .WithMany(u => u.ActivitiesFav)
                .UsingEntity(x => x.ToTable("FavActivities"));
            builder.Entity<Activity>()
                .HasMany(a => a.UsersPlay)
                .WithMany(u => u.ActivitiesPlay)
                .UsingEntity(x => x.ToTable("ActivityEnrollments"));

            builder.Entity<Activity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Activity>()
                .ToTable("Activity");

            builder.Entity<User>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<User>()
                .ToTable("User");
            builder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users);
            builder.Entity<User>()
                .HasOne(u => u.Status)
                .WithMany(uS => uS.Users)
                .HasForeignKey(u => u.StatusId);

            builder.Entity<Role>()
                .ToTable("Roles");

            builder.Entity<AssignedPermission>()
                .HasKey(x => new { x.RoleId, x.PermissionId, x.PermissionValueId });

            builder.Entity<UserStatus>()
                .HasData(InitialUserStatusData.GetUserStatuses().ToArray());
            builder.Entity<UserStatus>()
                .ToTable("UserStatus");

            builder.Entity<Role>()
                .HasData(InitialRoleData.GetRoleData().ToArray());
            builder.Entity<Role>()
                .ToTable("Role");

            builder.Entity<Permission>()
                .HasData(InitialPermissionData.GetPermissionData().ToArray());
            builder.Entity<Permission>()
                .ToTable("Permission");

            builder.Entity<PermissionValue>()
                .ToTable("PermissionValue");

            builder.Entity<ActivityType>()
                .HasData(InitialActivityTypeData.GetActivityTypes().ToArray());
            builder.Entity<ActivityType>()
                .ToTable("ActivityType");

            builder.Entity<ActivityStatus>()
                .HasData(InitialActivityStatusData.GetActivityStatuses().ToArray());
            builder.Entity<ActivityStatus>()
                .ToTable("ActivityStatus");

            builder.Entity<TimeSlot>()
                .HasData(InitialTimeSlotData.GetTimeSlotData().ToArray());
        }
    }
}