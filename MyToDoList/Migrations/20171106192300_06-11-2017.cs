using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyToDoList.Migrations
{
    public partial class _06112017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentWeekId",
                table: "Duties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CurrentWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MondayDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentWeek", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duties_CurrentWeekId",
                table: "Duties",
                column: "CurrentWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_CurrentWeek_CurrentWeekId",
                table: "Duties",
                column: "CurrentWeekId",
                principalTable: "CurrentWeek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_CurrentWeek_CurrentWeekId",
                table: "Duties");

            migrationBuilder.DropTable(
                name: "CurrentWeek");

            migrationBuilder.DropIndex(
                name: "IX_Duties_CurrentWeekId",
                table: "Duties");

            migrationBuilder.DropColumn(
                name: "CurrentWeekId",
                table: "Duties");
        }
    }
}
