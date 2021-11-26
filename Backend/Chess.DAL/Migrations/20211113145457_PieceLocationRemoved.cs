using Microsoft.EntityFrameworkCore.Migrations;

namespace Chess.DAL.Migrations
{
    public partial class PieceLocationRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PieceLocations_Lobbies_LobbyId",
                table: "PieceLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceLocations_UserData_UserId",
                table: "PieceLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_PieceLocations_MoveId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PieceLocations",
                table: "PieceLocations");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "PieceLocations");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PieceLocations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PieceLocations");

            migrationBuilder.RenameTable(
                name: "PieceLocations",
                newName: "Moves");

            migrationBuilder.RenameIndex(
                name: "IX_PieceLocations_UserId",
                table: "Moves",
                newName: "IX_Moves_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PieceLocations_LobbyId",
                table: "Moves",
                newName: "IX_Moves_LobbyId");

            migrationBuilder.AlterColumn<int>(
                name: "NewRow",
                table: "Moves",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewColumn",
                table: "Moves",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moves",
                table: "Moves",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Lobbies_LobbyId",
                table: "Moves",
                column: "LobbyId",
                principalTable: "Lobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_UserData_UserId",
                table: "Moves",
                column: "UserId",
                principalTable: "UserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Moves_MoveId",
                table: "Votes",
                column: "MoveId",
                principalTable: "Moves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Lobbies_LobbyId",
                table: "Moves");

            migrationBuilder.DropForeignKey(
                name: "FK_Moves_UserData_UserId",
                table: "Moves");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Moves_MoveId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Moves",
                table: "Moves");

            migrationBuilder.RenameTable(
                name: "Moves",
                newName: "PieceLocations");

            migrationBuilder.RenameIndex(
                name: "IX_Moves_UserId",
                table: "PieceLocations",
                newName: "IX_PieceLocations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Moves_LobbyId",
                table: "PieceLocations",
                newName: "IX_PieceLocations_LobbyId");

            migrationBuilder.AlterColumn<int>(
                name: "NewRow",
                table: "PieceLocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NewColumn",
                table: "PieceLocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "PieceLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PieceLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PieceLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PieceLocations",
                table: "PieceLocations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PieceLocations_Lobbies_LobbyId",
                table: "PieceLocations",
                column: "LobbyId",
                principalTable: "Lobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceLocations_UserData_UserId",
                table: "PieceLocations",
                column: "UserId",
                principalTable: "UserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_PieceLocations_MoveId",
                table: "Votes",
                column: "MoveId",
                principalTable: "PieceLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
