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
    [Migration("20220323140102_TimeslotNotNullable")]
    partial class TimeslotNotNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActivityEntityUserEntity", b =>
                {
                    b.Property<int>("ActivitiesCreateId")
                        .HasColumnType("int");

                    b.Property<int>("UsersCreateId")
                        .HasColumnType("int");

                    b.HasKey("ActivitiesCreateId", "UsersCreateId");

                    b.HasIndex("UsersCreateId");

                    b.ToTable("ActivityCreators");
                });

            modelBuilder.Entity("ActivityEntityUserEntity1", b =>
                {
                    b.Property<int>("ActivitiesFavId")
                        .HasColumnType("int");

                    b.Property<int>("UsersFavId")
                        .HasColumnType("int");

                    b.HasKey("ActivitiesFavId", "UsersFavId");

                    b.HasIndex("UsersFavId");

                    b.ToTable("FavActivities");
                });

            modelBuilder.Entity("ActivityEntityUserEntity2", b =>
                {
                    b.Property<int>("ActivitiesPlayId")
                        .HasColumnType("int");

                    b.Property<int>("UsersPlayId")
                        .HasColumnType("int");

                    b.HasKey("ActivitiesPlayId", "UsersPlayId");

                    b.HasIndex("UsersPlayId");

                    b.ToTable("ActivityEnrollments");
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleEntityUserEntity");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.ActivityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EditionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Places")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TimeSlotId");

                    b.HasIndex("TypeId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.ActivityStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActivityStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbr = "PEN",
                            Description = "Waiting for approval",
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Abbr = "ACT",
                            Description = "Accepted and waiting for participants",
                            Name = "Active"
                        },
                        new
                        {
                            Id = 3,
                            Abbr = "REV",
                            Description = "In revision process",
                            Name = "Revision"
                        },
                        new
                        {
                            Id = 4,
                            Abbr = "BAN",
                            Description = "Excluded as it doesn't align with the core values",
                            Name = "Banned"
                        });
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.ActivityTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActivityType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbr = "TTRPG",
                            Description = "Tabletop roleplaying game session",
                            Name = "Tabletop role-playing games"
                        },
                        new
                        {
                            Id = 2,
                            Abbr = "BG",
                            Description = "Board games for everyone!",
                            Name = "Board games"
                        },
                        new
                        {
                            Id = 3,
                            Abbr = "TOU",
                            Description = "A board or card game competition",
                            Name = "Tournament"
                        },
                        new
                        {
                            Id = 4,
                            Abbr = "DEM",
                            Description = "Show your brand new project to the community",
                            Name = "Demos"
                        },
                        new
                        {
                            Id = 5,
                            Abbr = "LARP",
                            Description = "Role-play games in live action",
                            Name = "Live action role-playing"
                        });
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.AssignedPermissionEntity", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionValueId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleId", "PermissionId", "PermissionValueId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("PermissionValueId");

                    b.ToTable("AssignedPermissions");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.EditionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInit")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Edition");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.EventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.PermissionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbr = "SEE",
                            Name = "See activities"
                        },
                        new
                        {
                            Id = 2,
                            Abbr = "REQJOIN",
                            Name = "Request join"
                        },
                        new
                        {
                            Id = 3,
                            Abbr = "MARKFAV",
                            Name = "Mark as favourite"
                        },
                        new
                        {
                            Id = 4,
                            Abbr = "ABANACT",
                            Name = "Abandon activity"
                        },
                        new
                        {
                            Id = 5,
                            Abbr = "PROPACT",
                            Name = "Propose activity"
                        },
                        new
                        {
                            Id = 6,
                            Abbr = "EDITACT",
                            Name = "Edit proposed activity"
                        },
                        new
                        {
                            Id = 7,
                            Abbr = "DELACT",
                            Name = "Delete proposed activity"
                        },
                        new
                        {
                            Id = 8,
                            Abbr = "SEEPART",
                            Name = "See participants"
                        },
                        new
                        {
                            Id = 9,
                            Abbr = "ACCACTEDIT",
                            Name = "Accept activity edit"
                        },
                        new
                        {
                            Id = 10,
                            Abbr = "ACCACTDEL",
                            Name = "Accept activity deletion"
                        },
                        new
                        {
                            Id = 11,
                            Abbr = "MARKREV",
                            Name = "Mark proposal for revision"
                        },
                        new
                        {
                            Id = 12,
                            Abbr = "CRTU",
                            Name = "Create user"
                        },
                        new
                        {
                            Id = 13,
                            Abbr = "DELU",
                            Name = "Delete user"
                        },
                        new
                        {
                            Id = 14,
                            Abbr = "BANU",
                            Name = "Ban user"
                        },
                        new
                        {
                            Id = 15,
                            Abbr = "ACCACTPROP",
                            Name = "Accept activity proposal"
                        },
                        new
                        {
                            Id = 16,
                            Abbr = "DELACTPROP",
                            Name = "Delete activity proposal"
                        },
                        new
                        {
                            Id = 17,
                            Abbr = "EDITU",
                            Name = "Edit user"
                        });
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.PermissionValueEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PermissionValue");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbr = "MNG",
                            Description = "Manager of the app",
                            EventId = 2,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 2,
                            Abbr = "OPR",
                            Description = "Operator in the app",
                            EventId = 2,
                            Name = "Operator"
                        },
                        new
                        {
                            Id = 3,
                            Abbr = "CRT",
                            Description = "Creator content in the events",
                            EventId = 2,
                            Name = "Creator"
                        },
                        new
                        {
                            Id = 4,
                            Abbr = "USR",
                            Description = "Player in the application",
                            EventId = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.TimeSlotEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TimeSlots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "MON"
                        },
                        new
                        {
                            Id = 2,
                            Name = "EVE"
                        },
                        new
                        {
                            Id = 3,
                            Name = "NGH"
                        });
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Blog")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbr = "PEN",
                            Description = "Pending to confirm",
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Abbr = "ACT",
                            Description = "Active user",
                            Name = "Active"
                        },
                        new
                        {
                            Id = 3,
                            Abbr = "REV",
                            Description = "In revision process",
                            Name = "Revision"
                        },
                        new
                        {
                            Id = 4,
                            Abbr = "BAN",
                            Description = "Banned from event",
                            Name = "Banned"
                        },
                        new
                        {
                            Id = 5,
                            Abbr = "INC",
                            Description = "Pending to confirm",
                            Name = "Inactive"
                        });
                });

            modelBuilder.Entity("ActivityEntityUserEntity", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.ActivityEntity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesCreateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaleEngine.Data.Contracts.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersCreateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ActivityEntityUserEntity1", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.ActivityEntity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesFavId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaleEngine.Data.Contracts.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersFavId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ActivityEntityUserEntity2", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.ActivityEntity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesPlayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaleEngine.Data.Contracts.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersPlayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaleEngine.Data.Contracts.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.ActivityEntity", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.EditionEntity", "Edition")
                        .WithMany("Activities")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaleEngine.Data.Contracts.Entities.ActivityStatusEntity", "Status")
                        .WithMany("Activities")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaleEngine.Data.Contracts.Entities.TimeSlotEntity", "TimeSlot")
                        .WithMany("Activities")
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaleEngine.Data.Contracts.Entities.ActivityTypeEntity", "Type")
                        .WithMany("Activities")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Edition");

                    b.Navigation("Status");

                    b.Navigation("TimeSlot");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.AssignedPermissionEntity", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.PermissionEntity", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaleEngine.Data.Contracts.Entities.PermissionValueEntity", "PermissionValue")
                        .WithMany()
                        .HasForeignKey("PermissionValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaleEngine.Data.Contracts.Entities.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("PermissionValue");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.EditionEntity", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.EventEntity", "Event")
                        .WithMany("Editions")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.RoleEntity", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.EventEntity", "Event")
                        .WithMany("Roles")
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserEntity", b =>
                {
                    b.HasOne("TaleEngine.Data.Contracts.Entities.UserStatusEntity", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.ActivityStatusEntity", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.ActivityTypeEntity", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.EditionEntity", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.EventEntity", b =>
                {
                    b.Navigation("Editions");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.TimeSlotEntity", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("TaleEngine.Data.Contracts.Entities.UserStatusEntity", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}