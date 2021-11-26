using Microsoft.EntityFrameworkCore.Migrations;

namespace Chess.DAL.Migrations
{
    public partial class changedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_LobbyConfigs_LobbyId",
                table: "UserData");

            migrationBuilder.RenameColumn(
                name: "LobbyId",
                table: "UserData",
                newName: "LobbyConfigId");

            migrationBuilder.RenameIndex(
                name: "IX_UserData_LobbyId",
                table: "UserData",
                newName: "IX_UserData_LobbyConfigId");

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
                name: "FK_UserData_LobbyConfigs_LobbyConfigId",
                table: "UserData");

            migrationBuilder.RenameColumn(
                name: "LobbyConfigId",
                table: "UserData",
                newName: "LobbyId");

            migrationBuilder.RenameIndex(
                name: "IX_UserData_LobbyConfigId",
                table: "UserData",
                newName: "IX_UserData_LobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_LobbyConfigs_LobbyId",
                table: "UserData",
                column: "LobbyId",
                principalTable: "LobbyConfigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
