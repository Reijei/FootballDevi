using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class asdads2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchModel",
                columns: table => new
                {
                    MatchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AwayCorners = table.Column<int>(nullable: true),
                    AwayFree = table.Column<int>(nullable: true),
                    AwayGoals = table.Column<int>(nullable: true),
                    AwayName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AwaySide = table.Column<int>(nullable: true),
                    AwayTotal = table.Column<int>(nullable: true),
                    AwayXg = table.Column<float>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: true),
                    HomeCorners = table.Column<int>(nullable: true),
                    HomeFree = table.Column<int>(nullable: true),
                    HomeGoals = table.Column<int>(nullable: true),
                    HomeName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HomeSide = table.Column<int>(nullable: true),
                    HomeTotal = table.Column<int>(nullable: true),
                    HomeXg = table.Column<float>(nullable: true)
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
                    Corners = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: true),
                    Free = table.Column<int>(nullable: true),
                    Goals = table.Column<int>(nullable: true),
                    Side = table.Column<int>(nullable: true),
                    TeamName = table.Column<string>(type: "nvarchar(50)", nullable: true),
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
                    Assist = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BigChange = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    BodyPart = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Breakway = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    DateTime = table.Column<DateTime>(nullable: true),
                    Defenders = table.Column<int>(nullable: true),
                    Half = table.Column<int>(nullable: true),
                    MatchID = table.Column<int>(nullable: true),
                    NoChange = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Opponent = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Pattern = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    PositionX = table.Column<double>(nullable: true),
                    PositionY = table.Column<double>(nullable: true),
                    PractiseID = table.Column<int>(nullable: true),
                    Result = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ShooterName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TeamName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Time = table.Column<int>(nullable: true),
                    Xg = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShotModel", x => x.ShotID);
                });
        }
    }
}
