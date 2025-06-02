using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonelProjectUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "PersonelProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "PersonelProjects",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveWork",
                table: "PersonelProjects",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "PersonelProjects",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.CreateIndex(
                name: "IX_PersonelProjects_BranchId",
                table: "PersonelProjects",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelProjects_Branches_BranchId",
                table: "PersonelProjects",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonelProjects_Branches_BranchId",
                table: "PersonelProjects");

            migrationBuilder.DropIndex(
                name: "IX_PersonelProjects_BranchId",
                table: "PersonelProjects");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "PersonelProjects");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "PersonelProjects");

            migrationBuilder.DropColumn(
                name: "IsActiveWork",
                table: "PersonelProjects");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "PersonelProjects");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b61401f1-c89c-4949-86d4-3bd332f3bd0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2a80e2b3-ca5a-439c-a1f6-7ae41449e641");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "3cb3c191-dcfb-44de-9e2c-d58e90aeea34");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "869b8df9-366a-42ef-9b7e-ab2a69ecc0a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "fb3868cc-d0c5-4c8f-8dcd-300626b500a6");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 31, 15, 8, 23, 376, DateTimeKind.Local).AddTicks(593), new DateTime(2025, 5, 31, 15, 8, 23, 376, DateTimeKind.Local).AddTicks(593) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 31, 15, 8, 23, 376, DateTimeKind.Local).AddTicks(597), new DateTime(2025, 5, 31, 15, 8, 23, 376, DateTimeKind.Local).AddTicks(597) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 15, 8, 23, 380, DateTimeKind.Local).AddTicks(935), new DateTime(2025, 5, 31, 15, 8, 23, 380, DateTimeKind.Local).AddTicks(940), new DateTime(2125, 5, 31, 15, 8, 23, 380, DateTimeKind.Local).AddTicks(942), new DateTime(2025, 5, 31, 15, 8, 23, 380, DateTimeKind.Local).AddTicks(942) });
        }
    }
}
