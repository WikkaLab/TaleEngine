using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TaleEngine.Data.Migrations
{
    public partial class ActivityTimeControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Activity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate",
                table: "Activity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "Activity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "Activity",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    LasModificationUserId = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_TimeSlotId",
                table: "Activity",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_TimeSlot_TimeSlotId",
                table: "Activity",
                column: "TimeSlotId",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_TimeSlot_TimeSlotId",
                table: "Activity");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_Activity_TimeSlotId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Activity");
        }
    }
}
