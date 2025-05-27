using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class addRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 13, 22, 15, 438, DateTimeKind.Local).AddTicks(9946), new DateTime(2025, 5, 27, 13, 22, 15, 438, DateTimeKind.Local).AddTicks(9944) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 5, 27, 13, 22, 15, 440, DateTimeKind.Local).AddTicks(2233), new DateTime(2025, 5, 27, 13, 22, 15, 440, DateTimeKind.Local).AddTicks(2242), new DateTime(2125, 5, 27, 13, 22, 15, 440, DateTimeKind.Local).AddTicks(2251), new DateTime(2025, 5, 27, 13, 22, 15, 440, DateTimeKind.Local).AddTicks(2249) });
        }
    }
}
