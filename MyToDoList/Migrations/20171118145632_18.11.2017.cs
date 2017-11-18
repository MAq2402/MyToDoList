using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyToDoList.Migrations
{
    public partial class _18112017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "OverdueDuties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverdueDuties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverdueDuties_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OverdueDuties_CategoryId",
                table: "OverdueDuties",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OverdueDuties");

            migrationBuilder.AddColumn<int>(
                name: "OverdueDutiesArchiveId",
                table: "Duties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OverdueDutiesArchive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
    }
}
