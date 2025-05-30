using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class TurskishCharacterForUSerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b097c90a-9357-45ab-8c5b-4ff47e6146e3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d1a477ea-41f3-41ef-bbe8-523682974307");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "d6ef46dd-6c8a-447b-88b0-8c0098dc6502");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "d05bab8d-d090-4b34-9913-f8efa068815d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "c0b8d540-d261-4570-9835-793ff4a91ea8");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 17, 51, 305, DateTimeKind.Local).AddTicks(9655), new DateTime(2025, 5, 30, 14, 17, 51, 305, DateTimeKind.Local).AddTicks(9655) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 17, 51, 305, DateTimeKind.Local).AddTicks(9659), new DateTime(2025, 5, 30, 14, 17, 51, 305, DateTimeKind.Local).AddTicks(9659) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 17, 51, 306, DateTimeKind.Local).AddTicks(6232), new DateTime(2025, 5, 30, 14, 17, 51, 306, DateTimeKind.Local).AddTicks(6235), new DateTime(2125, 5, 30, 14, 17, 51, 306, DateTimeKind.Local).AddTicks(6238), new DateTime(2025, 5, 30, 14, 17, 51, 306, DateTimeKind.Local).AddTicks(6237) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3559381f-aaab-4cfa-9727-acb33225b39f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "476f3835-39f7-4420-9d48-cd387e7fb98c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "e8fe3ec4-ab33-424a-be6d-97f359a6f5d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "ed2612d7-eb70-4519-ad63-ea733cfefc6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "1493d588-d142-48bf-af3a-d10aac3d58bc");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 2, 31, 896, DateTimeKind.Local).AddTicks(9228), new DateTime(2025, 5, 30, 9, 2, 31, 896, DateTimeKind.Local).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 2, 31, 896, DateTimeKind.Local).AddTicks(9232), new DateTime(2025, 5, 30, 9, 2, 31, 896, DateTimeKind.Local).AddTicks(9231) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 2, 31, 897, DateTimeKind.Local).AddTicks(3103), new DateTime(2025, 5, 30, 9, 2, 31, 897, DateTimeKind.Local).AddTicks(3107), new DateTime(2125, 5, 30, 9, 2, 31, 897, DateTimeKind.Local).AddTicks(3109), new DateTime(2025, 5, 30, 9, 2, 31, 897, DateTimeKind.Local).AddTicks(3109) });
        }
    }
}
