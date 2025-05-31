using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeExitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GiveDate",
                table: "Point",
                newName: "GiveDateStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "GiveDateFinish",
                table: "Point",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ManagerUserId",
                table: "Personel",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeExits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    StartWorkTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FinishWorkTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PersonelNoteAverage = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedByName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedByName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeExits_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                columns: new[] { "CreatedDate", "ManagerUserId", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 5, 31, 15, 8, 23, 380, DateTimeKind.Local).AddTicks(935), null, new DateTime(2025, 5, 31, 15, 8, 23, 380, DateTimeKind.Local).AddTicks(940), new DateTime(2125, 5, 31, 15, 8, 23, 380, DateTimeKind.Local).AddTicks(942), new DateTime(2025, 5, 31, 15, 8, 23, 380, DateTimeKind.Local).AddTicks(942) });

            migrationBuilder.CreateIndex(
                name: "IX_Personel_ManagerUserId",
                table: "Personel",
                column: "ManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExits_PersonelId",
                table: "EmployeeExits",
                column: "PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_AspNetUsers_ManagerUserId",
                table: "Personel",
                column: "ManagerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_AspNetUsers_ManagerUserId",
                table: "Personel");

            migrationBuilder.DropTable(
                name: "EmployeeExits");

            migrationBuilder.DropIndex(
                name: "IX_Personel_ManagerUserId",
                table: "Personel");

            migrationBuilder.DropColumn(
                name: "GiveDateFinish",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "ManagerUserId",
                table: "Personel");

            migrationBuilder.RenameColumn(
                name: "GiveDateStart",
                table: "Point",
                newName: "GiveDate");

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
    }
}
