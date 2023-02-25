using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    class_id = table.Column<int>(type: "INTEGER", nullable: false),
                    country_id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_classes_class_id",
                        column: x => x.class_id,
                        principalTable: "classes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_students_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "class_id", "country_id", "DateOfBirth", "name" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(1994, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emtious" },
                    { 2, 2, 1, new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riad" },
                    { 3, 1, 1, new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nabi" },
                    { 4, 1, 1, new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nira" },
                    { 5, 1, 1, new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nawaz" },
                    { 6, 2, 1, new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tanzir" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_class_id",
                table: "students",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_students_country_id",
                table: "students",
                column: "country_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
