using Microsoft.EntityFrameworkCore.Migrations;

namespace Chess.DAL.Migrations
{
    public partial class PropertyRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Team",
                table: "UserData",
                newName: "Side");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Side",
                table: "UserData",
                newName: "Team");
        }
    }
}
