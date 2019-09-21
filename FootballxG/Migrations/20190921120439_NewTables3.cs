using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class NewTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShotModel_MatchModel_MatchModelMatchID",
                table: "ShotModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ShotModel_PractiseModel_PractiseID",
                table: "ShotModel");

            migrationBuilder.DropIndex(
                name: "IX_ShotModel_MatchModelMatchID",
                table: "ShotModel");

            migrationBuilder.DropIndex(
                name: "IX_ShotModel_PractiseID",
                table: "ShotModel");

            migrationBuilder.DropColumn(
                name: "MatchModelMatchID",
                table: "ShotModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchModelMatchID",
                table: "ShotModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShotModel_MatchModelMatchID",
                table: "ShotModel",
                column: "MatchModelMatchID");

            migrationBuilder.CreateIndex(
                name: "IX_ShotModel_PractiseID",
                table: "ShotModel",
                column: "PractiseID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShotModel_MatchModel_MatchModelMatchID",
                table: "ShotModel",
                column: "MatchModelMatchID",
                principalTable: "MatchModel",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShotModel_PractiseModel_PractiseID",
                table: "ShotModel",
                column: "PractiseID",
                principalTable: "PractiseModel",
                principalColumn: "PractiseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
