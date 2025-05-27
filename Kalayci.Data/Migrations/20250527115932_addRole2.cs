using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class addRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "b10d0cc2-ff7e-4937-a8f2-e019f3e85dcf", "Admin", "ADMIN" },
                    { "2", "cce1584c-a2ad-4dee-8317-abb72431daec", "Yonetici", "YONETICI" },
                    { "3", "9f6b9242-1813-4b71-9407-05ebb18a6e13", "Muhendis", "MUHENDIS" },
                    { "4", "6a489a09-5176-40e9-8cc2-ad6999bd73df", "Atolye", "ATOLYE" }
                });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 14, 59, 30, 453, DateTimeKind.Local).AddTicks(4906), new DateTime(2025, 5, 27, 14, 59, 30, 453, DateTimeKind.Local).AddTicks(4904) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 5, 27, 14, 59, 30, 454, DateTimeKind.Local).AddTicks(9358), new DateTime(2025, 5, 27, 14, 59, 30, 454, DateTimeKind.Local).AddTicks(9368), new DateTime(2125, 5, 27, 14, 59, 30, 454, DateTimeKind.Local).AddTicks(9377), new DateTime(2025, 5, 27, 14, 59, 30, 454, DateTimeKind.Local).AddTicks(9375) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 14, 58, 0, 356, DateTimeKind.Local).AddTicks(7002), new DateTime(2025, 5, 27, 14, 58, 0, 356, DateTimeKind.Local).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 5, 27, 14, 58, 0, 357, DateTimeKind.Local).AddTicks(8475), new DateTime(2025, 5, 27, 14, 58, 0, 357, DateTimeKind.Local).AddTicks(8481), new DateTime(2125, 5, 27, 14, 58, 0, 357, DateTimeKind.Local).AddTicks(8489), new DateTime(2025, 5, 27, 14, 58, 0, 357, DateTimeKind.Local).AddTicks(8487) });
        }
    }
}
