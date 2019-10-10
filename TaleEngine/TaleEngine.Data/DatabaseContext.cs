using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .ToTable("Event");

            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Event)
                .WithMany(e => e.Activities)
                .HasForeignKey(a => a.EventId);
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Status)
                .WithMany(aS => aS.Activities)
                .HasForeignKey(a => a.StatusId);
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Type)
                .WithMany(aT => aT.Activities)
                .HasForeignKey(a => a.TypeId);

            modelBuilder.Entity<Activity>()
                .ToTable("Activity");


            modelBuilder.Entity<ActivityType>()
                .HasData(MockActivityTypeData.GetActivityTypes().ToArray());
            modelBuilder.Entity<ActivityType>()
                .Property(aT => aT.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ActivityType>()
                .ToTable("ActivityType");

            modelBuilder.Entity<ActivityStatus>()
                .HasData(MockActivityStatusData.GetActivityStatuses().ToArray());
            modelBuilder.Entity<ActivityStatus>()
                .Property(aS => aS.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ActivityStatus>()
                .ToTable("ActivityStatus");
        }
    }
}
