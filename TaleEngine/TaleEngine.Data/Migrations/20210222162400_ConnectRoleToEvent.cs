using Microsoft.EntityFrameworkCore.Migrations;

namespace TaleEngine.Data.Migrations
{
    public partial class ConnectRoleToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "EventId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "EventId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4,
                column: "EventId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Role_EventId",
                table: "Role",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Event_EventId",
                table: "Role",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Event_EventId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_EventId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Role");
        }
    }
}
