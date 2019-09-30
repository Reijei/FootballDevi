using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballxG.Migrations
{
    public partial class asdadsasddjj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Shot",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateTime",
                table: "Match",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateTime",
                table: "Shot",
                type: "nvarchar(12)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateTime",
                table: "Match",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
