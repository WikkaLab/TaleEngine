using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaleEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUserStatusDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Disabled due to inactivity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Pending to confirm");
        }
    }
}
