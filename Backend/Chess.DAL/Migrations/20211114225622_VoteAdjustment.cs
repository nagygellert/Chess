using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chess.DAL.Migrations
{
    public partial class VoteAdjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Moves_MoveId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_MoveId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "MoveId",
                table: "Votes");

            migrationBuilder.AddColumn<int>(
                name: "Column",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewColumn",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewRow",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Column",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "NewColumn",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "NewRow",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "Votes");

            migrationBuilder.AddColumn<Guid>(
                name: "MoveId",
                table: "Votes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_MoveId",
                table: "Votes",
                column: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Moves_MoveId",
                table: "Votes",
                column: "MoveId",
                principalTable: "Moves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
