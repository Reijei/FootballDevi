using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class NewTables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchModel",
                columns: table => new
                {
                    MatchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    HomeName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AwayName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HomeGoals = table.Column<int>(nullable: true),
                    AwayGoals = table.Column<int>(nullable: true),
                    HomeCorners = table.Column<int>(nullable: true),
                    AwayCorners = table.Column<int>(nullable: true),
                    HomeSide = table.Column<int>(nullable: true),
                    AwaySide = table.Column<int>(nullable: true),
                    HomeFree = table.Column<int>(nullable: true),
                    AwayFree = table.Column<int>(nullable: true),
                    HomeTotal = table.Column<int>(nullable: true),
                    AwayTotal = table.Column<int>(nullable: true),
                    HomeXg = table.Column<float>(nullable: true),
                    AwayXg = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchModel", x => x.MatchID);
                });

            migrationBuilder.CreateTable(
                name: "PractiseModel",
                columns: table => new
                {
                    PractiseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Goals = table.Column<int>(nullable: true),
                    Corners = table.Column<int>(nullable: true),
                    Side = table.Column<int>(nullable: true),
                    Free = table.Column<int>(nullable: true),
                    Total = table.Column<int>(nullable: true),
                    Xg = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PractiseModel", x => x.PractiseID);
                });

            migrationBuilder.CreateTable(
                name: "ShotModel",
                columns: table => new
                {
                    ShotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Time = table.Column<int>(nullable: true),
                    Half = table.Column<int>(nullable: true),
                    ShooterName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TeamName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Opponent = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Assist = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PositionX = table.Column<double>(nullable: false),
                    PositionY = table.Column<double>(nullable: false),
                    BodyPart = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Cross = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Pattern = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    BigChange = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    NoChange = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Defenders = table.Column<int>(nullable: true),
                    Xg = table.Column<float>(nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    TeamID = table.Column<int>(nullable: true),
                    PractiseID = table.Column<int>(nullable: true),
                    MatchModelMatchID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShotModel", x => x.ShotID);
                    table.ForeignKey(
                        name: "FK_ShotModel_MatchModel_MatchModelMatchID",
                        column: x => x.MatchModelMatchID,
                        principalTable: "MatchModel",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShotModel_PractiseModel_PractiseID",
                        column: x => x.PractiseID,
                        principalTable: "PractiseModel",
                        principalColumn: "PractiseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShotModel_MatchModelMatchID",
                table: "ShotModel",
                column: "MatchModelMatchID");

            migrationBuilder.CreateIndex(
                name: "IX_ShotModel_PractiseID",
                table: "ShotModel",
                column: "PractiseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShotModel");

            migrationBuilder.DropTable(
                name: "MatchModel");

            migrationBuilder.DropTable(
                name: "PractiseModel");
        }
    }
}
