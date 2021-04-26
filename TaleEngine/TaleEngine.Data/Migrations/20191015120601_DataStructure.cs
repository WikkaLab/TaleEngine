using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TaleEngine.Data.Migrations
{
    public partial class DataStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Event_EventId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Activity",
                newName: "EditionId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_EventId",
                table: "Activity",
                newName: "IX_Activity_EditionId");

            migrationBuilder.AddColumn<string>(
                name: "Abbr",
                table: "ActivityType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Abbr",
                table: "ActivityStatus",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Edition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    DateInit = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edition_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Abbr = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Abbr = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Abbr = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleToPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Blog = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "UserStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToActivityCreate",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false)
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

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Abbr",
                value: "PEN");

            migrationBuilder.UpdateData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Abbr",
                value: "ACT");

            migrationBuilder.InsertData(
                table: "ActivityStatus",
                columns: new[] { "Id", "Abbr", "CreateDateTime", "CreateUserId", "Description", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[,]
                {
                    { 3, "REV", null, null, "In revision process", null, null, "Revision" },
                    { 4, "BAN", null, null, "Excluded as it doesn't align with the core values", null, null, "Banned" }
                });

            migrationBuilder.UpdateData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Abbr", "Name" },
                values: new object[] { "TTRPG", "Tabletop role-playing games" });

            migrationBuilder.UpdateData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Abbr", "Name" },
                values: new object[] { "BG", "Board games" });

            migrationBuilder.InsertData(
                table: "ActivityType",
                columns: new[] { "Id", "Abbr", "CreateDateTime", "CreateUserId", "Description", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[,]
                {
                    { 4, "DEM", null, null, "Show your brand new project to the community", null, null, "Demos" },
                    { 5, "LARP", null, null, "Role-play games in live action", null, null, "Live action role-playing" },
                    { 3, "TOU", null, null, "A board or card game competition", null, null, "Tournament" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Abbr", "CreateDateTime", "CreateUserId", "Description", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[,]
                {
                    { 11, "MARKREV", null, null, null, null, null, "Mark proposal for revision" },
                    { 17, "EDITU", null, null, null, null, null, "Edit user" },
                    { 16, "DELACTPROP", null, null, null, null, null, "Delete activity proposal" },
                    { 15, "ACCACTPROP", null, null, null, null, null, "Accept activity proposal" },
                    { 14, "BANU", null, null, null, null, null, "Ban user" },
                    { 13, "DELU", null, null, null, null, null, "Delete user" },
                    { 12, "CRTU", null, null, null, null, null, "Create user" },
                    { 10, "ACCACTDEL", null, null, null, null, null, "Accept activity deletion" },
                    { 9, "ACCACTEDIT", null, null, null, null, null, "Accept activity edit" },
                    { 8, "SEEPART", null, null, null, null, null, "See participants" },
                    { 7, "DELACT", null, null, null, null, null, "Delete proposed activity" },
                    { 6, "EDITACT", null, null, null, null, null, "Edit proposed activity" },
                    { 5, "PROPACT", null, null, null, null, null, "Propose activity" },
                    { 4, "ABANACT", null, null, null, null, null, "Abandon activity" },
                    { 3, "MARKFAV", null, null, null, null, null, "Mark as favourite" },
                    { 2, "REQJOIN", null, null, null, null, null, "Request join" },
                    { 1, "SEE", null, null, null, null, null, "See activities" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Abbr", "CreateDateTime", "CreateUserId", "Description", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[,]
                {
                    { 4, "USR", null, null, "Player in the application", null, null, "User" },
                    { 3, "CRT", null, null, "Creator content in the events", null, null, "Creator" },
                    { 1, "MNG", null, null, "Manager of the app", null, null, "Manager" },
                    { 2, "OPR", null, null, "Operator in the app", null, null, "Operator" }
                });

            migrationBuilder.InsertData(
                table: "UserStatus",
                columns: new[] { "Id", "Abbr", "CreateDateTime", "CreateUserId", "Description", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[,]
                {
                    { 4, "BAN", null, null, "Banned from event", null, null, "Banned" },
                    { 1, "PEN", null, null, "Pending to confirm", null, null, "Pending" },
                    { 2, "ACT", null, null, "Active user", null, null, "Active" },
                    { 3, "REV", null, null, "In revision process", null, null, "Revision" },
                    { 5, "INC", null, null, "Pending to confirm", null, null, "Inactive" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edition_EventId",
                table: "Edition",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleToPermission_PermissionId",
                table: "RoleToPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_EventId",
                table: "User",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StatusId",
                table: "User",
                column: "StatusId");

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
                name: "FK_Activity_Edition_EditionId",
                table: "Activity",
                column: "EditionId",
                principalTable: "Edition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Edition_EditionId",
                table: "Activity");

            migrationBuilder.DropTable(
                name: "Edition");

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

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "UserStatus");

            migrationBuilder.DeleteData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActivityStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Abbr",
                table: "ActivityType");

            migrationBuilder.DropColumn(
                name: "Abbr",
                table: "ActivityStatus");

            migrationBuilder.RenameColumn(
                name: "EditionId",
                table: "Activity",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_EditionId",
                table: "Activity",
                newName: "IX_Activity_EventId");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Activity",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "TTRPG");

            migrationBuilder.UpdateData(
                table: "ActivityType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "BoardGames");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Event_EventId",
                table: "Activity",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
