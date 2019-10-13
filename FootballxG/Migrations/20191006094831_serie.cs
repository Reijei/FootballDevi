using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class serie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Serie",
                table: "Practise",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shot_PractiseID",
                table: "Shot",
                column: "PractiseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shot_Practise_PractiseID",
                table: "Shot",
                column: "PractiseID",
                principalTable: "Practise",
                principalColumn: "PractiseID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shot_Practise_PractiseID",
                table: "Shot");

            migrationBuilder.DropIndex(
                name: "IX_Shot_PractiseID",
                table: "Shot");

            migrationBuilder.DropColumn(
                name: "Serie",
                table: "Practise");
        }
    }
}
