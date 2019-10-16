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
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleToPermission> RoleToPermissions { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<UserToActivityCreate> UserToActivityCreates { get; set; }
        public DbSet<UserToActivityFav> UserToActivityFavs { get; set; }
        public DbSet<UserToActivityOperation> UserToActivityOperations { get; set; }
        public DbSet<UserToActivityPlay> UserToActivityPlays { get; set; }

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
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Activity>()
                .ToTable("Activity");

            builder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
            builder.Entity<User>()
                .HasOne(u => u.Status)
                .WithMany(uS => uS.Users)
                .HasForeignKey(u => u.StatusId);
            builder.Entity<User>()
                .HasOne(u => u.Event)
                .WithMany(ev => ev.RegisteredUsers)
                .HasForeignKey(u => u.EventId);

            builder.Entity<User>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<User>()
                .ToTable("User");

            builder.Entity<UserStatus>()
                .HasData(InitialUserStatusData.GetUserStatuses().ToArray());
            builder.Entity<UserStatus>()
                .ToTable("UserStatus");


            builder.Entity<UserToActivityCreate>()
                .HasKey(uta => new { uta.UserId, uta.ActivityId });
            builder.Entity<UserToActivityCreate>()
                .HasOne(uta => uta.User)
                .WithMany(u => u.ActivitiesCreate)
                .HasForeignKey(uta => uta.UserId);
            builder.Entity<UserToActivityCreate>()
                .HasOne(uta => uta.Activity)
                .WithMany(a => a.UsersCreate)
                .HasForeignKey(uta => uta.ActivityId);

            builder.Entity<UserToActivityCreate>()
                .ToTable("UserToActivityCreate");

            builder.Entity<UserToActivityFav>()
                .HasKey(uta => new { uta.UserId, uta.ActivityId });
            builder.Entity<UserToActivityFav>()
                .HasOne(uta => uta.User)
                .WithMany(u => u.ActivitiesFav)
                .HasForeignKey(uta => uta.UserId);
            builder.Entity<UserToActivityFav>()
                .HasOne(uta => uta.Activity)
                .WithMany(a => a.UsersFav)
                .HasForeignKey(uta => uta.ActivityId);

            builder.Entity<UserToActivityFav>()
                .ToTable("UserToActivityFav");

            builder.Entity<UserToActivityOperation>()
                .HasKey(uta => new { uta.UserId, uta.ActivityId });
            builder.Entity<UserToActivityOperation>()
                .HasOne(uta => uta.User)
                .WithMany(u => u.ActivitiesOperations)
                .HasForeignKey(uta => uta.UserId);
            builder.Entity<UserToActivityOperation>()
                .HasOne(uta => uta.Activity)
                .WithMany(a => a.UsersOperations)
                .HasForeignKey(uta => uta.ActivityId);
            builder.Entity<UserToActivityOperation>()
                .ToTable("UserToActivityOperation");

            builder.Entity<UserToActivityPlay>()
                .HasKey(uta => new { uta.UserId, uta.ActivityId });
            builder.Entity<UserToActivityPlay>()
                .HasOne(uta => uta.User)
                .WithMany(u => u.ActivitiesPlay)
                .HasForeignKey(uta => uta.UserId);
            builder.Entity<UserToActivityPlay>()
                .HasOne(uta => uta.Activity)
                .WithMany(a => a.UsersPlay)
                .HasForeignKey(uta => uta.ActivityId);
            builder.Entity<UserToActivityPlay>()
                .ToTable("UserToActivityPlay");

            builder.Entity<Role>()
                .HasData(InitialRoleData.GetRoleData().ToArray());
            builder.Entity<Role>()
                .ToTable("Role");

            builder.Entity<Permission>()
                .HasData(InitialPermissionData.GetPermissionData().ToArray());
            builder.Entity<Permission>()
                .ToTable("Permission");

            builder.Entity<RoleToPermission>()
                .HasKey(rTp => new { rTp.RoleId, rTp.PermissionId });
            builder.Entity<RoleToPermission>()
                .HasOne(rtp => rtp.Permission)
                .WithMany(p => p.Roles)
                .HasForeignKey(rtp => rtp.PermissionId);
            builder.Entity<RoleToPermission>()
                .HasOne(rtp => rtp.Role)
                .WithMany(r => r.Permissions)
                .HasForeignKey(rtp => rtp.RoleId);

            builder.Entity<RoleToPermission>()
                .ToTable("RoleToPermission");

            builder.Entity<ActivityType>()
                .HasData(InitialActivityTypeData.GetActivityTypes().ToArray());
            builder.Entity<ActivityType>()
                .ToTable("ActivityType");

            builder.Entity<ActivityStatus>()
                .HasData(InitialActivityStatusData.GetActivityStatuses().ToArray());
            builder.Entity<ActivityStatus>()
                .ToTable("ActivityStatus");
        }
    }
}
