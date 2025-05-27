using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class userUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 12, 57, 57, 516, DateTimeKind.Local).AddTicks(7286), new DateTime(2025, 5, 27, 12, 57, 57, 516, DateTimeKind.Local).AddTicks(7284) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 5, 27, 12, 57, 57, 518, DateTimeKind.Local).AddTicks(2742), new DateTime(2025, 5, 27, 12, 57, 57, 518, DateTimeKind.Local).AddTicks(2753), new DateTime(2125, 5, 27, 12, 57, 57, 518, DateTimeKind.Local).AddTicks(2759), new DateTime(2025, 5, 27, 12, 57, 57, 518, DateTimeKind.Local).AddTicks(2757) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "AspNetUsers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 12, 5, 18, 855, DateTimeKind.Local).AddTicks(1312), new DateTime(2025, 5, 27, 12, 5, 18, 855, DateTimeKind.Local).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 5, 27, 12, 5, 18, 857, DateTimeKind.Local).AddTicks(2818), new DateTime(2025, 5, 27, 12, 5, 18, 857, DateTimeKind.Local).AddTicks(2829), new DateTime(2125, 5, 27, 12, 5, 18, 857, DateTimeKind.Local).AddTicks(2837), new DateTime(2025, 5, 27, 12, 5, 18, 857, DateTimeKind.Local).AddTicks(2835) });
        }
    }
}
