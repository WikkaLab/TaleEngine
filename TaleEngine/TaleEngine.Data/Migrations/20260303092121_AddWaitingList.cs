using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaleEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWaitingList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityWaitingList",
                columns: table => new
                {
                    ActivitiesWaitingListId = table.Column<int>(type: "int", nullable: false),
                    UsersWaitingListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityWaitingList", x => new { x.ActivitiesWaitingListId, x.UsersWaitingListId });
                    table.ForeignKey(
                        name: "FK_ActivityWaitingList_Activity_ActivitiesWaitingListId",
                        column: x => x.ActivitiesWaitingListId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityWaitingList_User_UsersWaitingListId",
                        column: x => x.UsersWaitingListId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityWaitingList_UsersWaitingListId",
                table: "ActivityWaitingList",
                column: "UsersWaitingListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityWaitingList");
        }
    }
}
