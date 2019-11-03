using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class dbidchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Team",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Practise",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Match",
                type: "nvarchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Practise");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Match");
        }
    }
}
