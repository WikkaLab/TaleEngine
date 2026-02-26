using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaleEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class PermissionsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PermissionValue",
                columns: new[] { "Id", "Abbr", "CreateDateTime", "Description", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { 1, "ALLOW", null, null, null, "Allow" },
                    { 2, "DENY", null, null, null, "Deny" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionValue",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PermissionValue",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
