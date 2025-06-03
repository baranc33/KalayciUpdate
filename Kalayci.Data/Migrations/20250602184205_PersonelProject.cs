using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonelProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "PersonelProjects",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4a536b60-5f28-4a7e-a2ba-81d23f72aa96");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "349076d8-5920-420e-bd5d-b48b0ab8cd30");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "e790d7d6-d08c-4a8e-ae1e-d683b694a982");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "020a494d-07f3-471e-b781-55f3aef05c5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "ad9d8318-7bc0-405c-9a75-c3e4f29c5e9f");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 42, 3, 814, DateTimeKind.Local).AddTicks(76), new DateTime(2025, 6, 2, 21, 42, 3, 814, DateTimeKind.Local).AddTicks(76) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 42, 3, 814, DateTimeKind.Local).AddTicks(80), new DateTime(2025, 6, 2, 21, 42, 3, 814, DateTimeKind.Local).AddTicks(80) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 42, 3, 817, DateTimeKind.Local).AddTicks(9287), new DateTime(2025, 6, 2, 21, 42, 3, 817, DateTimeKind.Local).AddTicks(9293), new DateTime(2125, 6, 2, 21, 42, 3, 817, DateTimeKind.Local).AddTicks(9296), new DateTime(2025, 6, 2, 21, 42, 3, 817, DateTimeKind.Local).AddTicks(9295) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "PersonelProjects");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d0063eaa-c67a-41ee-ab7d-1e63ec344e10");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f8170ca0-4e0e-4569-978c-da9f2aefe8fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "d1ea4746-6960-44ba-a3b5-d7b54bec6d90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "620d1aae-a1ed-4427-843c-59268c1abe07");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "ea261d31-8b42-4403-b250-c6d835f83640");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 13, 32, 31, 931, DateTimeKind.Local).AddTicks(8807), new DateTime(2025, 6, 2, 13, 32, 31, 931, DateTimeKind.Local).AddTicks(8806) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 13, 32, 31, 931, DateTimeKind.Local).AddTicks(8811), new DateTime(2025, 6, 2, 13, 32, 31, 931, DateTimeKind.Local).AddTicks(8811) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 6, 2, 13, 32, 31, 935, DateTimeKind.Local).AddTicks(1877), new DateTime(2025, 6, 2, 13, 32, 31, 935, DateTimeKind.Local).AddTicks(1880), new DateTime(2125, 6, 2, 13, 32, 31, 935, DateTimeKind.Local).AddTicks(1883), new DateTime(2025, 6, 2, 13, 32, 31, 935, DateTimeKind.Local).AddTicks(1883) });
        }
    }
}
