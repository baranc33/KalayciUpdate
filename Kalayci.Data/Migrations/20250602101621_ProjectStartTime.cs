using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjectStartTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectFinishTime",
                table: "Project",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectStartTime",
                table: "Project",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectFinishTime",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectStartTime",
                table: "Project");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "caef6d07-4423-4b51-802d-b73be092a32b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "233f96d9-795f-48c7-8876-844cf23a71af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "0923149f-81ee-4e10-b386-a45ecdfcc89a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "f860a483-f09b-4cef-ad0e-be852e54ce1d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "096eba86-6aaa-4de2-a316-e1fd3b2fcd67");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 12, 21, 53, 145, DateTimeKind.Local).AddTicks(1527), new DateTime(2025, 6, 2, 12, 21, 53, 145, DateTimeKind.Local).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 12, 21, 53, 145, DateTimeKind.Local).AddTicks(1531), new DateTime(2025, 6, 2, 12, 21, 53, 145, DateTimeKind.Local).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 6, 2, 12, 21, 53, 148, DateTimeKind.Local).AddTicks(4823), new DateTime(2025, 6, 2, 12, 21, 53, 148, DateTimeKind.Local).AddTicks(4827), new DateTime(2125, 6, 2, 12, 21, 53, 148, DateTimeKind.Local).AddTicks(4829), new DateTime(2025, 6, 2, 12, 21, 53, 148, DateTimeKind.Local).AddTicks(4828) });
        }
    }
}
