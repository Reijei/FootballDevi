using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class changetable6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shot_Match_MatchID",
                table: "Shot");

            migrationBuilder.AlterColumn<int>(
                name: "MatchID",
                table: "Shot",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Shot_Match_MatchID",
                table: "Shot",
                column: "MatchID",
                principalTable: "Match",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shot_Match_MatchID",
                table: "Shot");

            migrationBuilder.AlterColumn<int>(
                name: "MatchID",
                table: "Shot",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shot_Match_MatchID",
                table: "Shot",
                column: "MatchID",
                principalTable: "Match",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
