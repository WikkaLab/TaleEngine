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
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

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
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
            builder.Entity<User>()
                .HasOne(u => u.Status)
                .WithMany(uS => uS.Users)
                .HasForeignKey(u => u.StatusId);

            builder.Entity<Role>()
                .ToTable("Roles");
            builder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithMany(p => p.Roles);

            builder.Entity<AssignedPermission>()
                .HasKey(x => new { x.RoleId, x.PermissionId, x.PermissionValueId });

            // Mock data

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
