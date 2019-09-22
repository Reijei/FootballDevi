using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class asdads222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateTime",
                table: "Match",
                type: "nvarchar(12)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shot_MatchID",
                table: "Shot",
                column: "MatchID");

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

            migrationBuilder.DropIndex(
                name: "IX_Shot_MatchID",
                table: "Shot");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Match",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldNullable: true);
        }
    }
}
