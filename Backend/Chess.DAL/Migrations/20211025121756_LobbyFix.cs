using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chess.DAL.Migrations
{
    public partial class LobbyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_Lobbies_LobbyId",
                table: "UserData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_LobbyConfigs_LobbyConfigId",
                table: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_UserData_LobbyConfigId",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "LobbyConfigId",
                table: "UserData");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_LobbyConfigs_LobbyId",
                table: "UserData",
                column: "LobbyId",
                principalTable: "LobbyConfigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_LobbyConfigs_LobbyId",
                table: "UserData");

            migrationBuilder.AddColumn<Guid>(
                name: "LobbyConfigId",
                table: "UserData",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_LobbyConfigId",
                table: "UserData",
                column: "LobbyConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_Lobbies_LobbyId",
                table: "UserData",
                column: "LobbyId",
                principalTable: "Lobbies",
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
    }
}
