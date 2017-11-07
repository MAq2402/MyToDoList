using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyToDoList.Migrations
{
    public partial class _07112017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_CurrentWeek_CurrentWeekId",
                table: "Duties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentWeek",
                table: "CurrentWeek");

            migrationBuilder.RenameTable(
                name: "CurrentWeek",
                newName: "CurrentWeeks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentWeeks",
                table: "CurrentWeeks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_CurrentWeeks_CurrentWeekId",
                table: "Duties",
                column: "CurrentWeekId",
                principalTable: "CurrentWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_CurrentWeeks_CurrentWeekId",
                table: "Duties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentWeeks",
                table: "CurrentWeeks");

            migrationBuilder.RenameTable(
                name: "CurrentWeeks",
                newName: "CurrentWeek");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentWeek",
                table: "CurrentWeek",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_CurrentWeek_CurrentWeekId",
                table: "Duties",
                column: "CurrentWeekId",
                principalTable: "CurrentWeek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
