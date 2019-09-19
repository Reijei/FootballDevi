using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations.DataDb
{
    public partial class testi23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(nullable: true),
                    Wins = table.Column<int>(nullable: false),
                    Loses = table.Column<int>(nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamID = table.Column<int>(nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    No = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Matches = table.Column<int>(nullable: false),
                    Goals = table.Column<int>(nullable: false),
                    Passes = table.Column<int>(nullable: false),
                    Spots = table.Column<int>(nullable: false),
                    CardYellow = table.Column<int>(nullable: false),
                    CardRed = table.Column<int>(nullable: false),
                    Xg = table.Column<double>(nullable: false),
                    XgP = table.Column<double>(nullable: false),
                    Xa = table.Column<double>(nullable: false),
                    XaP = table.Column<double>(nullable: false),
                    Xg90 = table.Column<double>(nullable: false),
                    Xa90 = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamID",
                table: "Player",
                column: "TeamID");
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
