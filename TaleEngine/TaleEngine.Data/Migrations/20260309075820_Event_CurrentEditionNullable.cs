using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaleEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class Event_CurrentEditionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Event_CurrentEditionId",
                table: "Event");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentEditionId",
                table: "Event",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CurrentEditionId",
                table: "Event",
                column: "CurrentEditionId",
                unique: true,
                filter: "[CurrentEditionId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Event_CurrentEditionId",
                table: "Event");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentEditionId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_CurrentEditionId",
                table: "Event",
                column: "CurrentEditionId",
                unique: true);
        }
    }
}
