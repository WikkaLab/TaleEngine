using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaleEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class CurrentEditionInEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentEditionId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Event_CurrentEditionId",
                table: "Event",
                column: "CurrentEditionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Edition_CurrentEditionId",
                table: "Event",
                column: "CurrentEditionId",
                principalTable: "Edition",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Edition_CurrentEditionId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_CurrentEditionId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "CurrentEditionId",
                table: "Event");
        }
    }
}
