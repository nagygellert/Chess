using Microsoft.EntityFrameworkCore.Migrations;

namespace Chess.DAL.Migrations
{
    public partial class AddedTeamToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Team",
                table: "UserData",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team",
                table: "UserData");
        }
    }
}
