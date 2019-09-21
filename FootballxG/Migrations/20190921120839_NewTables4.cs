using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class NewTables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cross",
                table: "ShotModel",
                newName: "Breakway");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Breakway",
                table: "ShotModel",
                newName: "Cross");
        }
    }
}
