using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class userNameLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "varchar(11840)",
                maxLength: 11840,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 13, 10, 56, 844, DateTimeKind.Local).AddTicks(4988), new DateTime(2025, 5, 27, 13, 10, 56, 844, DateTimeKind.Local).AddTicks(4986) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 5, 27, 13, 10, 56, 845, DateTimeKind.Local).AddTicks(7316), new DateTime(2025, 5, 27, 13, 10, 56, 845, DateTimeKind.Local).AddTicks(7324), new DateTime(2125, 5, 27, 13, 10, 56, 845, DateTimeKind.Local).AddTicks(7332), new DateTime(2025, 5, 27, 13, 10, 56, 845, DateTimeKind.Local).AddTicks(7330) });
        }
    }
}
