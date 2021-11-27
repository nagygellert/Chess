using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chess.DAL.Migrations
{
    public partial class cleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_LobbyConfigs_LobbyId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "RoundStart",
                table: "LobbyConfigs");

            migrationBuilder.AddColumn<int>(
                name: "PieceType",
                table: "Moves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Lobbies_LobbyId",
                table: "ChatMessages",
                column: "LobbyId",
                principalTable: "Lobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Lobbies_LobbyId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "PieceType",
                table: "Moves");

            migrationBuilder.AddColumn<DateTime>(
                name: "RoundStart",
                table: "LobbyConfigs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_LobbyConfigs_LobbyId",
                table: "ChatMessages",
                column: "LobbyId",
                principalTable: "LobbyConfigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
