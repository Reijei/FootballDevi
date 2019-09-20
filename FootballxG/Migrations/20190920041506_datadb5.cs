using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class datadb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamID = table.Column<int>(nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    No = table.Column<int>(nullable: true),
                    Position = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Matches = table.Column<int>(nullable: true),
                    Minutes = table.Column<int>(nullable: true),
                    Goals = table.Column<int>(nullable: true),
                    Passes = table.Column<int>(nullable: true),
                    Spots = table.Column<int>(nullable: true),
                    CardYellow = table.Column<int>(nullable: true),
                    CardRed = table.Column<int>(nullable: true),
                    Xg = table.Column<double>(nullable: true),
                    XgP = table.Column<double>(nullable: true),
                    Xa = table.Column<double>(nullable: true),
                    XaP = table.Column<double>(nullable: true),
                    Xg90 = table.Column<double>(nullable: true),
                    Xa90 = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerID);
                });

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
