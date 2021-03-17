using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaleEngine.Data.Migrations
{
    public partial class RemoveFieldsBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Event_EventId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "UserStatus");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "UserStatus");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "PermissionValue");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "PermissionValue");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Edition");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "Edition");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "AssignedPermissions");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "AssignedPermissions");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "ActivityType");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "ActivityType");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "ActivityStatus");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "ActivityStatus");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "LastModificationUserId",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "UserStatus",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "User",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "TimeSlot",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "Role",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "PermissionValue",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "Permission",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "Event",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "Edition",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "AssignedPermissions",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "ActivityType",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "ActivityStatus",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationDateTime",
                table: "Activity",
                newName: "ModificationDate");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Role",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Event_EventId",
                table: "Role",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Event_EventId",
                table: "Role");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "UserStatus",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "User",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "TimeSlot",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Role",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "PermissionValue",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Permission",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Event",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Edition",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "AssignedPermissions",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "ActivityType",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "ActivityStatus",
                newName: "LastModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Activity",
                newName: "LastModificationDateTime");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "UserStatus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "UserStatus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "TimeSlot",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "TimeSlot",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "PermissionValue",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "PermissionValue",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "Permission",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "Permission",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "Event",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "Event",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "Edition",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "Edition",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "AssignedPermissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "AssignedPermissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "ActivityType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "ActivityType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "ActivityStatus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "ActivityStatus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "Activity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModificationUserId",
                table: "Activity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Event_EventId",
                table: "Role",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
