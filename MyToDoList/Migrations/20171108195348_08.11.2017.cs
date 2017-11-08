using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyToDoList.Migrations
{
    public partial class _08112017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_CurrentWeeks_CurrentWeekId",
                table: "Duties");

            migrationBuilder.DropIndex(
                name: "IX_Duties_CurrentWeekId",
                table: "Duties");

            migrationBuilder.DropColumn(
                name: "CurrentWeekId",
                table: "Duties");

            migrationBuilder.AddColumn<int>(
                name: "AmmountOfDoneDutiesArchiveId",
                table: "CurrentWeeks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AmmountOfDoneDutiesArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FridayDoneDuties = table.Column<int>(type: "int", nullable: false),
                    MondayDoneDuties = table.Column<int>(type: "int", nullable: false),
                    SaturdayDoneDuties = table.Column<int>(type: "int", nullable: false),
                    SundayDoneDuties = table.Column<int>(type: "int", nullable: false),
                    ThursdayDoneDuties = table.Column<int>(type: "int", nullable: false),
                    TuesdayDoneDuties = table.Column<int>(type: "int", nullable: false),
                    WednesdayDoneDuties = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmmountOfDoneDutiesArchives", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentWeeks_AmmountOfDoneDutiesArchiveId",
                table: "CurrentWeeks",
                column: "AmmountOfDoneDutiesArchiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentWeeks_AmmountOfDoneDutiesArchives_AmmountOfDoneDutiesArchiveId",
                table: "CurrentWeeks",
                column: "AmmountOfDoneDutiesArchiveId",
                principalTable: "AmmountOfDoneDutiesArchives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentWeeks_AmmountOfDoneDutiesArchives_AmmountOfDoneDutiesArchiveId",
                table: "CurrentWeeks");

            migrationBuilder.DropTable(
                name: "AmmountOfDoneDutiesArchives");

            migrationBuilder.DropIndex(
                name: "IX_CurrentWeeks_AmmountOfDoneDutiesArchiveId",
                table: "CurrentWeeks");

            migrationBuilder.DropColumn(
                name: "AmmountOfDoneDutiesArchiveId",
                table: "CurrentWeeks");

            migrationBuilder.AddColumn<int>(
                name: "CurrentWeekId",
                table: "Duties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Duties_CurrentWeekId",
                table: "Duties",
                column: "CurrentWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_CurrentWeeks_CurrentWeekId",
                table: "Duties",
                column: "CurrentWeekId",
                principalTable: "CurrentWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
