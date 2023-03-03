using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "create_date",
                table: "students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_date",
                table: "students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_date",
                table: "countries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_date",
                table: "countries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_date",
                table: "classes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_date",
                table: "classes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(427), null });

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(464), null });

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(474), null });

            migrationBuilder.UpdateData(
                table: "countries",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(485), null });

            migrationBuilder.UpdateData(
                table: "countries",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(547), null });

            migrationBuilder.UpdateData(
                table: "countries",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(557), null });

            migrationBuilder.UpdateData(
                table: "countries",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(565), null });

            migrationBuilder.UpdateData(
                table: "countries",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(573), null });

            migrationBuilder.UpdateData(
                table: "countries",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(583), null });

            migrationBuilder.UpdateData(
                table: "countries",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(592), null });

            migrationBuilder.UpdateData(
                table: "countries",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(600), null });

            migrationBuilder.UpdateData(
                table: "countries",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(607), null });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(624), null });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(636), null });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(644), null });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(653), null });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(662), null });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_date", "modified_date" },
                values: new object[] { new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(672), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_date",
                table: "students");

            migrationBuilder.DropColumn(
                name: "modified_date",
                table: "students");

            migrationBuilder.DropColumn(
                name: "create_date",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "modified_date",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "create_date",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "modified_date",
                table: "classes");
        }
    }
}
