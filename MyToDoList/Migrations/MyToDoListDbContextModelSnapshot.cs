﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MyToDoList.DbContexts;
using MyToDoList.Enums;
using System;

namespace MyToDoList.Migrations
{
    [DbContext(typeof(MyToDoListDbContext))]
    partial class MyToDoListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyToDoList.Entities.AmmountOfDoneDutiesArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FridayDoneDuties");

                    b.Property<int>("MondayDoneDuties");

                    b.Property<int>("SaturdayDoneDuties");

                    b.Property<int>("SundayDoneDuties");

                    b.Property<int>("ThursdayDoneDuties");

                    b.Property<int>("TuesdayDoneDuties");

                    b.Property<int>("WednesdayDoneDuties");

                    b.HasKey("Id");

                    b.ToTable("AmmountOfDoneDutiesArchives");
                });

            modelBuilder.Entity("MyToDoList.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyToDoList.Entities.CurrentWeek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmmountOfDoneDutiesArchiveId");

                    b.Property<DateTime>("MondayDate");

                    b.HasKey("Id");

                    b.HasIndex("AmmountOfDoneDutiesArchiveId");

                    b.ToTable("CurrentWeeks");
                });

            modelBuilder.Entity("MyToDoList.Entities.Duty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<int>("Day");

                    b.Property<int>("OverdueDutiesArchiveId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OverdueDutiesArchiveId");

                    b.ToTable("Duties");
                });

            modelBuilder.Entity("MyToDoList.Entities.OverdueDutiesArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("OverdueDutiesArchive");
                });

            modelBuilder.Entity("MyToDoList.Entities.CurrentWeek", b =>
                {
                    b.HasOne("MyToDoList.Entities.AmmountOfDoneDutiesArchive", "AmmountOfDoneDutiesArchive")
                        .WithMany()
                        .HasForeignKey("AmmountOfDoneDutiesArchiveId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyToDoList.Entities.Duty", b =>
                {
                    b.HasOne("MyToDoList.Entities.Category", "Category")
                        .WithMany("Duties")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyToDoList.Entities.OverdueDutiesArchive", "OverdueDutiesArchive")
                        .WithMany("Duties")
                        .HasForeignKey("OverdueDutiesArchiveId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
