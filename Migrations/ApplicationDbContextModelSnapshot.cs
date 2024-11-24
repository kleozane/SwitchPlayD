﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwitchPlayD.Data;

#nullable disable

namespace SwitchPlayD.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Navigation("StudioCategories");
                });

            modelBuilder.Entity("SwitchPlayD.Data.Studio", b =>
                {
                    b.Navigation("StudioCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
