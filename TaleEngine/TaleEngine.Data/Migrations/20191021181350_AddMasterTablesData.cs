using Microsoft.EntityFrameworkCore.Migrations;

namespace TaleEngine.Data.Migrations
{
    public partial class AddMasterTablesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "CreateDateTime", "CreateUserId", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[] { 1, null, null, null, null, "MON" });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "CreateDateTime", "CreateUserId", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[] { 2, null, null, null, null, "EVE" });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "CreateDateTime", "CreateUserId", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[] { 3, null, null, null, null, "NGH" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
