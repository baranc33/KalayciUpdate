using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShipYardManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonelID",
                table: "ShipYard",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipYardManagementName",
                table: "ShipYard",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_ShipYard_PersonelID",
                table: "ShipYard",
                column: "PersonelID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipYard_Personel_PersonelID",
                table: "ShipYard",
                column: "PersonelID",
                principalTable: "Personel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipYard_Personel_PersonelID",
                table: "ShipYard");

            migrationBuilder.DropIndex(
                name: "IX_ShipYard_PersonelID",
                table: "ShipYard");

            migrationBuilder.DropColumn(
                name: "PersonelID",
                table: "ShipYard");

            migrationBuilder.DropColumn(
                name: "ShipYardManagementName",
                table: "ShipYard");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6abe8fbc-2446-4cda-9d6f-ae8b41cd87ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3fb60dbf-e864-43c8-aaae-9ea6c39d9164");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "afb9ff52-8eac-4cc2-985d-84abb83c0bf2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "b470a2c8-fd53-4523-9549-9221940b7c01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "e747ad4f-3c89-4a47-a247-c631fcb32405");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 13, 16, 20, 408, DateTimeKind.Local).AddTicks(5842), new DateTime(2025, 6, 2, 13, 16, 20, 408, DateTimeKind.Local).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 13, 16, 20, 408, DateTimeKind.Local).AddTicks(5845), new DateTime(2025, 6, 2, 13, 16, 20, 408, DateTimeKind.Local).AddTicks(5845) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 6, 2, 13, 16, 20, 411, DateTimeKind.Local).AddTicks(7225), new DateTime(2025, 6, 2, 13, 16, 20, 411, DateTimeKind.Local).AddTicks(7228), new DateTime(2125, 6, 2, 13, 16, 20, 411, DateTimeKind.Local).AddTicks(7233), new DateTime(2025, 6, 2, 13, 16, 20, 411, DateTimeKind.Local).AddTicks(7233) });
        }
    }
}
