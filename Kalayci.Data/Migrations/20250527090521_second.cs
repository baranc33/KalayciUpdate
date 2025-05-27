using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorizedProject",
                table: "Personel");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 12, 5, 18, 855, DateTimeKind.Local).AddTicks(1312), new DateTime(2025, 5, 27, 12, 5, 18, 855, DateTimeKind.Local).AddTicks(1310) });

            migrationBuilder.InsertData(
                table: "Personel",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "Name", "Phone", "Picture", "WorkFinishDate", "WorkStartDate", "branchId" },
                values: new object[] { 1, "System", new DateTime(2025, 5, 27, 12, 5, 18, 857, DateTimeKind.Local).AddTicks(2818), false, "İşlem", "System", new DateTime(2025, 5, 27, 12, 5, 18, 857, DateTimeKind.Local).AddTicks(2829), "Bilgi", "555 004 63 33", null, new DateTime(2125, 5, 27, 12, 5, 18, 857, DateTimeKind.Local).AddTicks(2837), new DateTime(2025, 5, 27, 12, 5, 18, 857, DateTimeKind.Local).AddTicks(2835), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "AutorizedProject",
                table: "Personel",
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
                values: new object[] { new DateTime(2025, 5, 27, 9, 17, 16, 719, DateTimeKind.Local).AddTicks(8931), new DateTime(2025, 5, 27, 9, 17, 16, 719, DateTimeKind.Local).AddTicks(8930) });
        }
    }
}
