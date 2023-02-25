using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedClassNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "id",
                keyValue: 1,
                column: "class_name",
                value: "First Class");

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "id",
                keyValue: 2,
                column: "class_name",
                value: "Second Class");

            migrationBuilder.InsertData(
                table: "classes",
                columns: new[] { "id", "class_name" },
                values: new object[] { 3, "Third Class" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "classes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "id",
                keyValue: 1,
                column: "class_name",
                value: "Math");

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "id",
                keyValue: 2,
                column: "class_name",
                value: "English");
        }
    }
}
