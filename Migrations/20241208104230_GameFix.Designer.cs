﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwitchPlayD.Data;

#nullable disable

namespace SwitchPlayD.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241208104230_GameFix")]
    partial class GameFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SwitchPlayD.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SwitchPlayD.Data.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<int>("StudioId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudioId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SwitchPlayD.Data.GameCategory", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("GameCategories");
                });

            modelBuilder.Entity("SwitchPlayD.Data.GamePlatform", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("GamePlatforms");
                });

            modelBuilder.Entity("SwitchPlayD.Data.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Playstation"
                        },
                        new
                        {
                            Id = 2,
                            Name = "xBox"
                        },
                        new
                        {
                            Id = 3,
                            Name = "PC"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nintendo"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mobile"
                        });
                });

            modelBuilder.Entity("SwitchPlayD.Data.Studio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("SwitchPlayD.Data.StudioCategory", b =>
                {
                    b.Property<int>("StudioId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("StudioId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("StudioCategories");
                });

            modelBuilder.Entity("SwitchPlayD.Data.Game", b =>
                {
                    b.HasOne("SwitchPlayD.Data.Studio", "Studio")
                        .WithMany("Games")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("SwitchPlayD.Data.GameCategory", b =>
                {
                    b.HasOne("SwitchPlayD.Data.Category", "Category")
                        .WithMany("GameCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SwitchPlayD.Data.Game", "Game")
                        .WithMany("GameCategories")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("SwitchPlayD.Data.GamePlatform", b =>
                {
                    b.HasOne("SwitchPlayD.Data.Game", "Game")
                        .WithMany("GamePlatforms")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SwitchPlayD.Data.Platform", "Platform")
                        .WithMany("GamePlatforms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("SwitchPlayD.Data.StudioCategory", b =>
                {
                    b.HasOne("SwitchPlayD.Data.Category", "Category")
                        .WithMany("StudioCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SwitchPlayD.Data.Studio", "Studio")
                        .WithMany("StudioCategories")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("SwitchPlayD.Data.Category", b =>
                {
                    b.Navigation("GameCategories");

                    b.Navigation("StudioCategories");
                });

            modelBuilder.Entity("SwitchPlayD.Data.Game", b =>
                {
                    b.Navigation("GameCategories");

                    b.Navigation("GamePlatforms");
                });

            modelBuilder.Entity("SwitchPlayD.Data.Platform", b =>
                {
                    b.Navigation("GamePlatforms");
                });

            modelBuilder.Entity("SwitchPlayD.Data.Studio", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("StudioCategories");
                });
#pragma warning restore 612, 618
        }
    }
}