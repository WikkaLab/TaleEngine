using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Data;

namespace TaleEngine.Data
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json")
                   .Build();

                optionsBuilder
                    .UseSqlServer(configuration["ConnectionString"],
                        x => x.MigrationsAssembly("TaleEngine.Data"))
                    .EnableSensitiveDataLogging();
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

        public DbSet<EventEntity> Events { get; set; }
        public DbSet<ActivityEntity> Activities { get; set; }
        public DbSet<ActivityTypeEntity> ActivityTypes { get; set; }
        public DbSet<ActivityStatusEntity> ActivityStatuses { get; set; }
        public DbSet<UserStatusEntity> UserStatuses { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<PermissionValueEntity> PermissionsValue { get; set; }
        public DbSet<AssignedPermissionEntity> AssignedPermissions { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<EditionEntity> Editions { get; set; }
        public DbSet<TimeSlotEntity> TimeSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EventEntity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<EventEntity>()
                .HasOne(ev => ev.CurrentEdition)
                .WithOne(ed => ed.IsCurrentEditionInEvent)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<EventEntity>()
                .ToTable("Event");

            builder.Entity<EditionEntity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<EditionEntity>()
                .HasOne(ed => ed.Event)
                .WithMany(ev => ev.Editions)
                .HasForeignKey(ed => ed.EventId);
            builder.Entity<EditionEntity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<EditionEntity>()
                .ToTable("Edition");

            builder.Entity<ActivityEntity>()
                .HasOne(a => a.Edition)
                .WithMany(ed => ed.Activities)
                .HasForeignKey(a => a.EditionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ActivityEntity>()
                .HasOne(a => a.TimeSlot)
                .WithMany(tS => tS.Activities)
                .HasForeignKey(a => a.TimeSlotId);
            builder.Entity<ActivityEntity>()
                .HasOne(a => a.Status)
                .WithMany(aS => aS.Activities)
                .HasForeignKey(a => a.StatusId);
            builder.Entity<ActivityEntity>()
                .HasOne(a => a.Type)
                .WithMany(aT => aT.Activities)
                .HasForeignKey(a => a.TypeId);
            builder.Entity<ActivityEntity>()
                .HasMany(a => a.UsersCreate)
                .WithMany(u => u.ActivitiesCreate)
                .UsingEntity(x => x.ToTable("ActivityCreators"));
            builder.Entity<ActivityEntity>()
                .HasMany(a => a.UsersFav)
                .WithMany(u => u.ActivitiesFav)
                .UsingEntity(x => x.ToTable("FavActivities"));
            builder.Entity<ActivityEntity>()
                .HasMany(a => a.UsersPlay)
                .WithMany(u => u.ActivitiesPlay)
                .UsingEntity(x => x.ToTable("ActivityEnrollments"));

            builder.Entity<ActivityEntity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ActivityEntity>()
                .ToTable("Activity");

            builder.Entity<UserEntity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<UserEntity>()
                .ToTable("User");
            builder.Entity<UserEntity>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users);
            builder.Entity<UserEntity>()
                .HasOne(u => u.Status)
                .WithMany(uS => uS.Users)
                .HasForeignKey(u => u.StatusId);

            builder.Entity<RoleEntity>()
                .ToTable("Roles");

            builder.Entity<AssignedPermissionEntity>()
                .HasKey(x => new { x.RoleId, x.PermissionId, x.PermissionValueId });

            builder.Entity<UserStatusEntity>()
                .HasData(InitialUserStatusData.GetUserStatuses().ToArray());
            builder.Entity<UserStatusEntity>()
                .ToTable("UserStatus");

            builder.Entity<RoleEntity>()
                .HasData(InitialRoleData.GetRoleData().ToArray());
            builder.Entity<RoleEntity>()
                .ToTable("Role");

            builder.Entity<PermissionEntity>()
                .HasData(InitialPermissionData.GetPermissionData().ToArray());
            builder.Entity<PermissionEntity>()
                .ToTable("Permission");

            builder.Entity<PermissionValueEntity>()
                .ToTable("PermissionValue");

            builder.Entity<ActivityTypeEntity>()
                .HasData(InitialActivityTypeData.GetActivityTypes().ToArray());
            builder.Entity<ActivityTypeEntity>()
                .ToTable("ActivityType");

            builder.Entity<ActivityStatusEntity>()
                .HasData(InitialActivityStatusData.GetActivityStatuses().ToArray());
            builder.Entity<ActivityStatusEntity>()
                .ToTable("ActivityStatus");

            builder.Entity<TimeSlotEntity>()
                .HasData(InitialTimeSlotData.GetTimeSlotData().ToArray());
        }
    }
}