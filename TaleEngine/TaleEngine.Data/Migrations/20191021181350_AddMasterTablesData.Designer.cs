﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaleEngine.Data;

namespace TaleEngine.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191021181350_AddMasterTablesData")]
    partial class AddMasterTablesData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<string>("Description");

                    b.Property<int>("EditionId");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<string>("Image");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<int>("Places");

                    b.Property<DateTime>("PublicationDate");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<int>("StatusId");

                    b.Property<int?>("TimeSlotId");

                    b.Property<string>("Title");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TimeSlotId");

                    b.HasIndex("TypeId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.ActivityStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr");

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<string>("Description");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ActivityStatus");

                    b.HasData(
                        new { Id = 1, Abbr = "PEN", Description = "Waiting for approval", Name = "Pending" },
                        new { Id = 2, Abbr = "ACT", Description = "Accepted and waiting for participants", Name = "Active" },
                        new { Id = 3, Abbr = "REV", Description = "In revision process", Name = "Revision" },
                        new { Id = 4, Abbr = "BAN", Description = "Excluded as it doesn't align with the core values", Name = "Banned" }
                    );
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.ActivityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr");

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<string>("Description");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ActivityType");

                    b.HasData(
                        new { Id = 1, Abbr = "TTRPG", Description = "Tabletop roleplaying game session", Name = "Tabletop role-playing games" },
                        new { Id = 2, Abbr = "BG", Description = "Board games for everyone!", Name = "Board games" },
                        new { Id = 3, Abbr = "TOU", Description = "A board or card game competition", Name = "Tournament" },
                        new { Id = 4, Abbr = "DEM", Description = "Show your brand new project to the community", Name = "Demos" },
                        new { Id = 5, Abbr = "LARP", Description = "Role-play games in live action", Name = "Live action role-playing" }
                    );
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateInit");

                    b.Property<int>("EventId");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Edition");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr");

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<string>("Description");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new { Id = 1, Abbr = "SEE", Name = "See activities" },
                        new { Id = 2, Abbr = "REQJOIN", Name = "Request join" },
                        new { Id = 3, Abbr = "MARKFAV", Name = "Mark as favourite" },
                        new { Id = 4, Abbr = "ABANACT", Name = "Abandon activity" },
                        new { Id = 5, Abbr = "PROPACT", Name = "Propose activity" },
                        new { Id = 6, Abbr = "EDITACT", Name = "Edit proposed activity" },
                        new { Id = 7, Abbr = "DELACT", Name = "Delete proposed activity" },
                        new { Id = 8, Abbr = "SEEPART", Name = "See participants" },
                        new { Id = 9, Abbr = "ACCACTEDIT", Name = "Accept activity edit" },
                        new { Id = 10, Abbr = "ACCACTDEL", Name = "Accept activity deletion" },
                        new { Id = 11, Abbr = "MARKREV", Name = "Mark proposal for revision" },
                        new { Id = 12, Abbr = "CRTU", Name = "Create user" },
                        new { Id = 13, Abbr = "DELU", Name = "Delete user" },
                        new { Id = 14, Abbr = "BANU", Name = "Ban user" },
                        new { Id = 15, Abbr = "ACCACTPROP", Name = "Accept activity proposal" },
                        new { Id = 16, Abbr = "DELACTPROP", Name = "Delete activity proposal" },
                        new { Id = 17, Abbr = "EDITU", Name = "Edit user" }
                    );
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr");

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<string>("Description");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new { Id = 1, Abbr = "MNG", Description = "Manager of the app", Name = "Manager" },
                        new { Id = 2, Abbr = "OPR", Description = "Operator in the app", Name = "Operator" },
                        new { Id = 3, Abbr = "CRT", Description = "Creator content in the events", Name = "Creator" },
                        new { Id = 4, Abbr = "USR", Description = "Player in the application", Name = "User" }
                    );
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.RoleToPermission", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("PermissionId");

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<int>("Id");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("RoleToPermission");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.TimeSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TimeSlot");

                    b.HasData(
                        new { Id = 1, Name = "MON" },
                        new { Id = 2, Name = "EVE" },
                        new { Id = 3, Name = "NGH" }
                    );
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Blog");

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<int>("EventId");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<int>("StatusId");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StatusId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr");

                    b.Property<DateTime?>("CreateDateTime");

                    b.Property<Guid?>("CreateUserId");

                    b.Property<string>("Description");

                    b.Property<Guid?>("LasModificationUserId");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserStatus");

                    b.HasData(
                        new { Id = 1, Abbr = "PEN", Description = "Pending to confirm", Name = "Pending" },
                        new { Id = 2, Abbr = "ACT", Description = "Active user", Name = "Active" },
                        new { Id = 3, Abbr = "REV", Description = "In revision process", Name = "Revision" },
                        new { Id = 4, Abbr = "BAN", Description = "Banned from event", Name = "Banned" },
                        new { Id = 5, Abbr = "INC", Description = "Pending to confirm", Name = "Inactive" }
                    );
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserToActivityCreate", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ActivityId");

                    b.HasKey("UserId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("UserToActivityCreate");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserToActivityFav", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ActivityId");

                    b.HasKey("UserId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("UserToActivityFav");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserToActivityOperation", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ActivityId");

                    b.HasKey("UserId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("UserToActivityOperation");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserToActivityPlay", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ActivityId");

                    b.HasKey("UserId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("UserToActivityPlay");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.Activity", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.Edition", "Edition")
                        .WithMany("Activities")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TaleEngine.Data.Contracts.Entities.ActivityStatus", "Status")
                        .WithMany("Activities")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaleEngine.Data.Contracts.Entities.TimeSlot", "TimeSlot")
                        .WithMany("Activities")
                        .HasForeignKey("TimeSlotId");

                    b.HasOne("TaleEngine.Data.Contracts.Entities.ActivityType", "Type")
                        .WithMany("Activities")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.Edition", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.Event", "Event")
                        .WithMany("Editions")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.RoleToPermission", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.Permission", "Permission")
                        .WithMany("Roles")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaleEngine.Data.Contracts.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.User", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.Event", "Event")
                        .WithMany("RegisteredUsers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaleEngine.Data.Contracts.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaleEngine.Data.Contracts.Entities.UserStatus", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserToActivityCreate", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.Activity", "Activity")
                        .WithMany("UsersCreate")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaleEngine.Data.Contracts.Entities.User", "User")
                        .WithMany("ActivitiesCreate")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserToActivityFav", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.Activity", "Activity")
                        .WithMany("UsersFav")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaleEngine.Data.Contracts.Entities.User", "User")
                        .WithMany("ActivitiesFav")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserToActivityOperation", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.Activity", "Activity")
                        .WithMany("UsersOperations")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaleEngine.Data.Contracts.Entities.User", "User")
                        .WithMany("ActivitiesOperations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserToActivityPlay", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.Activity", "Activity")
                        .WithMany("UsersPlay")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaleEngine.Data.Contracts.Entities.User", "User")
                        .WithMany("ActivitiesPlay")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}