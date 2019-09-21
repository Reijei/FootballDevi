using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class asdads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "ShotModel",
                newName: "MatchID");

            migrationBuilder.AlterColumn<double>(
                name: "PositionY",
                table: "ShotModel",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "PositionX",
                table: "ShotModel",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchID",
                table: "ShotModel",
                newName: "TeamID");

            migrationBuilder.AlterColumn<double>(
                name: "PositionY",
                table: "ShotModel",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PositionX",
                table: "ShotModel",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
