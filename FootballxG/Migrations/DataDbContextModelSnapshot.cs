﻿// <auto-generated />
using System;
using FootballxG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballxG.Migrations
{
    [DbContext(typeof(DataDbContext))]
    partial class DataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootballxG.Models.Match", b =>
                {
                    b.Property<int?>("MatchID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AwayCorners");

                    b.Property<int?>("AwayFree");

                    b.Property<int?>("AwayGoals");

                    b.Property<string>("AwayName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("AwaySide");

                    b.Property<int?>("AwayTotal");

                    b.Property<float?>("AwayXg");

                    b.Property<DateTime?>("DateTime");

                    b.Property<int?>("HomeCorners");

                    b.Property<int?>("HomeFree");

                    b.Property<int?>("HomeGoals");

                    b.Property<string>("HomeName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("HomeSide");

                    b.Property<int?>("HomeTotal");

                    b.Property<float?>("HomeXg");

                    b.Property<string>("Serie")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MatchID");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("FootballxG.Models.Player", b =>
                {
                    b.Property<int?>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CardRed");

                    b.Property<int?>("CardYellow");

                    b.Property<int?>("Goals");

                    b.Property<int?>("Matches");

                    b.Property<int?>("Minutes");

                    b.Property<int?>("No");

                    b.Property<int?>("Passes");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Spots");

                    b.Property<int?>("TeamID");

                    b.Property<float?>("Xa");

                    b.Property<float?>("Xa90");

                    b.Property<float?>("XaP");

                    b.Property<float?>("Xg");

                    b.Property<float?>("Xg90");

                    b.Property<float?>("XgP");

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("FootballxG.Models.Practise", b =>
                {
                    b.Property<int?>("PractiseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Corners");

                    b.Property<DateTime?>("DateTime");

                    b.Property<int?>("Free");

                    b.Property<int?>("Goals");

                    b.Property<string>("Serie")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Side");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Total");

                    b.Property<float?>("Xg");

                    b.HasKey("PractiseID");

                    b.ToTable("Practise");
                });

            modelBuilder.Entity("FootballxG.Models.Shot", b =>
                {
                    b.Property<int?>("ShotID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assist")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BigChange")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("BodyPart")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Breakway")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("DateTime");

                    b.Property<int?>("Defenders");

                    b.Property<int?>("Half");

                    b.Property<int?>("MatchID");

                    b.Property<string>("NoChange")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Opponent")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pattern")
                        .HasColumnType("nvarchar(10)");

                    b.Property<double?>("PositionX");

                    b.Property<double?>("PositionY");

                    b.Property<int?>("PractiseID");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ShooterName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Time");

                    b.Property<float?>("Xg");

                    b.HasKey("ShotID");

                    b.HasIndex("MatchID");

                    b.HasIndex("PractiseID");

                    b.ToTable("Shot");
                });

            modelBuilder.Entity("FootballxG.Models.Team", b =>
                {
                    b.Property<int?>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Loses");

                    b.Property<int?>("Position");

                    b.Property<string>("Serie")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Wins");

                    b.HasKey("TeamID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("FootballxG.Models.Player", b =>
                {
                    b.HasOne("FootballxG.Models.Team", "Team")
                        .WithMany("Player")
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("FootballxG.Models.Shot", b =>
                {
                    b.HasOne("FootballxG.Models.Match", "Match")
                        .WithMany("Shot")
                        .HasForeignKey("MatchID");

                    b.HasOne("FootballxG.Models.Practise", "Practise")
                        .WithMany("Shot")
                        .HasForeignKey("PractiseID");
                });
#pragma warning restore 612, 618
        }
    }
}
