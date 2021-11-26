using Microsoft.EntityFrameworkCore.Migrations;

namespace Chess.DAL.Migrations
{
    public partial class LobbyConfigUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomCode",
                table: "LobbyConfigs");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "LobbyConfigs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LobbyConfigs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "LobbyConfigs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "LobbyConfigs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LobbyConfigs");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "LobbyConfigs");

            migrationBuilder.AddColumn<int>(
                name: "RoomCode",
                table: "LobbyConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
