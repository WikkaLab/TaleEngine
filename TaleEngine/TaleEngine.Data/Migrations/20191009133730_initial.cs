using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Diagnostics.CodeAnalysis;

namespace TaleEngine.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Places = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ActivityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ActivityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActivityStatus",
                columns: new[] { "Id", "CreateDateTime", "CreateUserId", "Description", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Waiting for approval", null, null, "Pending" },
                    { 2, null, null, "Accepted and waiting for participants", null, null, "Active" }
                });

            migrationBuilder.InsertData(
                table: "ActivityType",
                columns: new[] { "Id", "CreateDateTime", "CreateUserId", "Description", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Tabletop roleplaying game session", null, null, "TTRPG" },
                    { 2, null, null, "Board games for everyone!", null, null, "BoardGames" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_EventId",
                table: "Activity",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_StatusId",
                table: "Activity",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_TypeId",
                table: "Activity",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "ActivityStatus");

            migrationBuilder.DropTable(
                name: "ActivityType");
        }
    }
}