using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyToDoList.Migrations
{
    public partial class _10112017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OverdueDutiesArchiveId",
                table: "Duties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OverdueDutiesArchive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverdueDutiesArchive", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duties_OverdueDutiesArchiveId",
                table: "Duties",
                column: "OverdueDutiesArchiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_OverdueDutiesArchive_OverdueDutiesArchiveId",
                table: "Duties",
                column: "OverdueDutiesArchiveId",
                principalTable: "OverdueDutiesArchive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_OverdueDutiesArchive_OverdueDutiesArchiveId",
                table: "Duties");

            migrationBuilder.DropTable(
                name: "OverdueDutiesArchive");

            migrationBuilder.DropIndex(
                name: "IX_Duties_OverdueDutiesArchiveId",
                table: "Duties");

            migrationBuilder.DropColumn(
                name: "OverdueDutiesArchiveId",
                table: "Duties");
        }
    }
}
