using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chess.DAL.Migrations
{
    public partial class LobbyConfigModifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserProfileId",
                table: "UserData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LobbyConfigId",
                table: "UserData",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "LobbyConfigs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomCode",
                table: "LobbyConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_LobbyConfigId",
                table: "UserData",
                column: "LobbyConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyConfigs_OwnerId",
                table: "LobbyConfigs",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LobbyConfigs_UserData_OwnerId",
                table: "LobbyConfigs",
                column: "OwnerId",
                principalTable: "UserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_LobbyConfigs_LobbyConfigId",
                table: "UserData",
                column: "LobbyConfigId",
                principalTable: "LobbyConfigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LobbyConfigs_UserData_OwnerId",
                table: "LobbyConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_LobbyConfigs_LobbyConfigId",
                table: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_UserData_LobbyConfigId",
                table: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_LobbyConfigs_OwnerId",
                table: "LobbyConfigs");

            migrationBuilder.DropColumn(
                name: "LobbyConfigId",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "LobbyConfigs");

            migrationBuilder.DropColumn(
                name: "RoomCode",
                table: "LobbyConfigs");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserProfileId",
                table: "UserData",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
