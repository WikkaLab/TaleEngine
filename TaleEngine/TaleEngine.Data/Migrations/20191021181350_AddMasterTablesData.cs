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

            migrationBuilder.InsertData(
                table: "ActivityStatus",
                columns: new[] { "Id", "Abbr", "CreateDateTime", "CreateUserId", "Description", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[,]
                {
                    { 1, "PEN", null, null, "Waiting for approval", null, null, "Pending" },
                    { 2, "ACT", null, null, "Accepted and waiting for participants", null, null, "Active" }
                });

            migrationBuilder.InsertData(
                table: "ActivityType",
                columns: new[] { "Id", "Abbr", "CreateDateTime", "CreateUserId", "Description", "LasModificationUserId", "LastModificationDateTime", "Name" },
                values: new object[,]
                {
                    { 1, "TTRPG", null, null, "Tabletop role-playing games", null, null, "Tabletop role-playing games" },
                    { 2, "BG", null, null, "Board games for everyone!", null, null, "Board games" }
                });
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

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
               table: "ActivityType",
               keyColumn: "Id",
               keyValue: 1);

            migrationBuilder.DeleteData(
               table: "ActivityType",
               keyColumn: "Id",
               keyValue: 2);

            migrationBuilder.DeleteData(
               table: "ActivityStatus",
               keyColumn: "Id",
               keyValue: 1);

            migrationBuilder.DeleteData(
               table: "ActivityStatus",
               keyColumn: "Id",
               keyValue: 2);
        }
    }
}
