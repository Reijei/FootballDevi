﻿// <auto-generated />
using System;
using FootballxG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballxG.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20190920090952_foreignkey")]
    partial class foreignkey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("TeamID");

                    b.Property<double?>("Xa");

                    b.Property<double?>("Xa90");

                    b.Property<double?>("XaP");

                    b.Property<double?>("Xg");

                    b.Property<double?>("Xg90");

                    b.Property<double?>("XgP");

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Player");
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
                    b.HasOne("FootballxG.Models.Team", "team")
                        .WithMany()
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
