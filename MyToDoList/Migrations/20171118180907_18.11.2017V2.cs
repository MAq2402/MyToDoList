using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyToDoList.Migrations
{
    public partial class _18112017V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MondayDate",
                table: "CurrentWeeks");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CurrentWeeks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "CurrentWeeks");

            migrationBuilder.AddColumn<DateTime>(
                name: "MondayDate",
                table: "CurrentWeeks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
