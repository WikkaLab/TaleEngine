using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TaleEngine.Data.Migrations
{
    public partial class ReorganizeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Event_EventId",
                table: "User");

            migrationBuilder.DropTable(
                name: "RoleToPermission");

            migrationBuilder.DropTable(
                name: "UserToActivityCreate");

            migrationBuilder.DropTable(
                name: "UserToActivityFav");

            migrationBuilder.DropTable(
                name: "UserToActivityOperation");

            migrationBuilder.DropTable(
                name: "UserToActivityPlay");

            migrationBuilder.DropIndex(
                name: "IX_User_EventId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "LasModificationUserId",
                table: "UserStatus",
                newName: "LastModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LasModificationUserId",
                table: "User",
                newName: "LastModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LasModificationUserId",
                table: "TimeSlot",
                newName: "LastModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LasModificationUserId",
                table: "Role",
                newName: "LastModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LasModificationUserId",
                table: "Permission",
                newName: "LastModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LasModificationUserId",
                table: "Event",
                newName: "LastModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LasModificationUserId",
                table: "Edition",
                newName: "LastModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LasModificationUserId",
                table: "ActivityType",
                newName: "LastModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LasModificationUserId",
                table: "ActivityStatus",
                newName: "LastModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LasModificationUserId",
                table: "Activity",
                newName: "LastModificationUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDateTime",
                table: "Activity",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDateTime",
                table: "Activity",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "ActivityCreators",
                columns: table => new
                {
                    ActivitiesCreateId = table.Column<int>(type: "int", nullable: false),
                    UsersCreateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCreators", x => new { x.ActivitiesCreateId, x.UsersCreateId });
                    table.ForeignKey(
                        name: "FK_ActivityCreators_Activity_ActivitiesCreateId",
                        column: x => x.ActivitiesCreateId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityCreators_User_UsersCreateId",
                        column: x => x.UsersCreateId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityEnrollments",
                columns: table => new
                {
                    ActivitiesPlayId = table.Column<int>(type: "int", nullable: false),
                    UsersPlayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityEnrollments", x => new { x.ActivitiesPlayId, x.UsersPlayId });
                    table.ForeignKey(
                        name: "FK_ActivityEnrollments_Activity_ActivitiesPlayId",
                        column: x => x.ActivitiesPlayId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityEnrollments_User_UsersPlayId",
                        column: x => x.UsersPlayId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavActivities",
                columns: table => new
                {
                    ActivitiesFavId = table.Column<int>(type: "int", nullable: false),
                    UsersFavId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavActivities", x => new { x.ActivitiesFavId, x.UsersFavId });
                    table.ForeignKey(
                        name: "FK_FavActivities_Activity_ActivitiesFavId",
                        column: x => x.ActivitiesFavId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavActivities_User_UsersFavId",
                        column: x => x.UsersFavId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRole",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRole", x => new { x.PermissionsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_PermissionRole_Permission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRole_Role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignedPermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    PermissionValueId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedPermissions", x => new { x.RoleId, x.PermissionId, x.PermissionValueId });
                    table.ForeignKey(
                        name: "FK_AssignedPermissions_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedPermissions_PermissionValue_PermissionValueId",
                        column: x => x.PermissionValueId,
                        principalTable: "PermissionValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedPermissions_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCreators_UsersCreateId",
                table: "ActivityCreators",
                column: "UsersCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEnrollments_UsersPlayId",
                table: "ActivityEnrollments",
                column: "UsersPlayId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedPermissions_PermissionId",
                table: "AssignedPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedPermissions_PermissionValueId",
                table: "AssignedPermissions",
                column: "PermissionValueId");

            migrationBuilder.CreateIndex(
                name: "IX_FavActivities_UsersFavId",
                table: "FavActivities",
                column: "UsersFavId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRole_RolesId",
                table: "PermissionRole",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityCreators");

            migrationBuilder.DropTable(
                name: "ActivityEnrollments");

            migrationBuilder.DropTable(
                name: "AssignedPermissions");

            migrationBuilder.DropTable(
                name: "FavActivities");

            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DropTable(
                name: "PermissionValue");

            migrationBuilder.RenameColumn(
                name: "LastModificationUserId",
                table: "UserStatus",
                newName: "LasModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LastModificationUserId",
                table: "User",
                newName: "LasModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LastModificationUserId",
                table: "TimeSlot",
                newName: "LasModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LastModificationUserId",
                table: "Role",
                newName: "LasModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LastModificationUserId",
                table: "Permission",
                newName: "LasModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LastModificationUserId",
                table: "Event",
                newName: "LasModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LastModificationUserId",
                table: "Edition",
                newName: "LasModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LastModificationUserId",
                table: "ActivityType",
                newName: "LasModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LastModificationUserId",
                table: "ActivityStatus",
                newName: "LasModificationUserId");

            migrationBuilder.RenameColumn(
                name: "LastModificationUserId",
                table: "Activity",
                newName: "LasModificationUserId");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDateTime",
                table: "Activity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDateTime",
                table: "Activity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RoleToPermission",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LasModificationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleToPermission", x => new { x.RoleId, x.PermissionId });
                    table.UniqueConstraint("AK_RoleToPermission_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleToPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleToPermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToActivityCreate",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToActivityCreate", x => new { x.UserId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_UserToActivityCreate_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToActivityCreate_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToActivityFav",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToActivityFav", x => new { x.UserId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_UserToActivityFav_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToActivityFav_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToActivityOperation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToActivityOperation", x => new { x.UserId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_UserToActivityOperation_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToActivityOperation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToActivityPlay",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToActivityPlay", x => new { x.UserId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_UserToActivityPlay_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToActivityPlay_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_EventId",
                table: "User",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleToPermission_PermissionId",
                table: "RoleToPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToActivityCreate_ActivityId",
                table: "UserToActivityCreate",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToActivityFav_ActivityId",
                table: "UserToActivityFav",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToActivityOperation_ActivityId",
                table: "UserToActivityOperation",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToActivityPlay_ActivityId",
                table: "UserToActivityPlay",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Event_EventId",
                table: "User",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
