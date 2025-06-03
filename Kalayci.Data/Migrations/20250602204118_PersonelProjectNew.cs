using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonelProjectNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonelProjects",
                table: "PersonelProjects");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PersonelProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonelProjects",
                table: "PersonelProjects",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e62c6ba9-80e7-4dca-a75e-ab1de77b649f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8e407950-b816-44c7-99b3-998df1c1c260");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a048cb1e-bc74-4dc6-8554-8ea6b8ce269e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "7e116ea3-2538-44d4-aa58-a95477ed2f35");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "4ab48841-dfd9-4db7-a397-d1ee67d4f33e");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 23, 41, 17, 376, DateTimeKind.Local).AddTicks(6969), new DateTime(2025, 6, 2, 23, 41, 17, 376, DateTimeKind.Local).AddTicks(6968) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 23, 41, 17, 376, DateTimeKind.Local).AddTicks(7014), new DateTime(2025, 6, 2, 23, 41, 17, 376, DateTimeKind.Local).AddTicks(7013) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 6, 2, 23, 41, 17, 380, DateTimeKind.Local).AddTicks(5351), new DateTime(2025, 6, 2, 23, 41, 17, 380, DateTimeKind.Local).AddTicks(5354), new DateTime(2125, 6, 2, 23, 41, 17, 380, DateTimeKind.Local).AddTicks(5357), new DateTime(2025, 6, 2, 23, 41, 17, 380, DateTimeKind.Local).AddTicks(5356) });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelProjects_ProjectId",
                table: "PersonelProjects",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonelProjects",
                table: "PersonelProjects");

            migrationBuilder.DropIndex(
                name: "IX_PersonelProjects_ProjectId",
                table: "PersonelProjects");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PersonelProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonelProjects",
                table: "PersonelProjects",
                columns: new[] { "ProjectId", "PersonelId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a96bec45-b5b2-410d-9924-25e0b9eff419");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ab2140db-ef13-48e8-b40f-2e4c3a49aaf1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a36ac316-7040-456e-a44c-04afb0b00195");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "64c7da6f-5484-44ef-80b9-fe6cedb3f17b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "c28d37dc-d37f-421c-bdf4-13e491c1f48f");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 23, 36, 46, 733, DateTimeKind.Local).AddTicks(950), new DateTime(2025, 6, 2, 23, 36, 46, 733, DateTimeKind.Local).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 23, 36, 46, 733, DateTimeKind.Local).AddTicks(955), new DateTime(2025, 6, 2, 23, 36, 46, 733, DateTimeKind.Local).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 6, 2, 23, 36, 46, 737, DateTimeKind.Local).AddTicks(6245), new DateTime(2025, 6, 2, 23, 36, 46, 737, DateTimeKind.Local).AddTicks(6255), new DateTime(2125, 6, 2, 23, 36, 46, 737, DateTimeKind.Local).AddTicks(6259), new DateTime(2025, 6, 2, 23, 36, 46, 737, DateTimeKind.Local).AddTicks(6258) });
        }
    }
}
