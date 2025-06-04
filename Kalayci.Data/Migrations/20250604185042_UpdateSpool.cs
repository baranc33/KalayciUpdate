using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSpool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spool_CircuitList_CircuitListId",
                table: "Spool");

            migrationBuilder.DropIndex(
                name: "IX_Spool_CircuitListId",
                table: "Spool");

            migrationBuilder.DropColumn(
                name: "CircuitListId",
                table: "Spool");

            migrationBuilder.AlterColumn<string>(
                name: "Shipmentlocation",
                table: "Spool",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Block",
                table: "Spool",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CircuitName",
                table: "Spool",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Diameter",
                table: "Spool",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "No",
                table: "Spool",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TotalKg",
                table: "Spool",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9422c4ad-d3b6-4b5f-8085-e50b10fea8bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7474b1c9-2c55-494c-90e4-6c3baa2efeb4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "8066ffba-ab65-4dbe-bb18-4111a8c88c3d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "2eba72db-d1ba-497c-8422-11ef12302e49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "3e89ca6e-9884-4fa3-a91e-e25d096408a4");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 50, 41, 259, DateTimeKind.Local).AddTicks(9883), new DateTime(2025, 6, 4, 21, 50, 41, 259, DateTimeKind.Local).AddTicks(9883) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 50, 41, 259, DateTimeKind.Local).AddTicks(9887), new DateTime(2025, 6, 4, 21, 50, 41, 259, DateTimeKind.Local).AddTicks(9887) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 50, 41, 263, DateTimeKind.Local).AddTicks(5972), new DateTime(2025, 6, 4, 21, 50, 41, 263, DateTimeKind.Local).AddTicks(5975), new DateTime(2125, 6, 4, 21, 50, 41, 263, DateTimeKind.Local).AddTicks(5978), new DateTime(2025, 6, 4, 21, 50, 41, 263, DateTimeKind.Local).AddTicks(5977) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Block",
                table: "Spool");

            migrationBuilder.DropColumn(
                name: "CircuitName",
                table: "Spool");

            migrationBuilder.DropColumn(
                name: "Diameter",
                table: "Spool");

            migrationBuilder.DropColumn(
                name: "No",
                table: "Spool");

            migrationBuilder.DropColumn(
                name: "TotalKg",
                table: "Spool");

            migrationBuilder.AlterColumn<byte>(
                name: "Shipmentlocation",
                table: "Spool",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CircuitListId",
                table: "Spool",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bdfbc430-c2be-484c-ad55-fde18aaa07dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "96c2dda9-0310-403c-aeaa-5b5b661bd86f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "62b24807-3ff9-4400-91dd-32232bb95105");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "0b5d537e-d943-47d6-8568-f2a9b20f691e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "7e127d1c-782e-40e9-96d2-5d5a80e2c233");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 16, 19, 35, 924, DateTimeKind.Local).AddTicks(3928), new DateTime(2025, 6, 3, 16, 19, 35, 924, DateTimeKind.Local).AddTicks(3927) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 16, 19, 35, 924, DateTimeKind.Local).AddTicks(3932), new DateTime(2025, 6, 3, 16, 19, 35, 924, DateTimeKind.Local).AddTicks(3931) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 6, 3, 16, 19, 35, 929, DateTimeKind.Local).AddTicks(9048), new DateTime(2025, 6, 3, 16, 19, 35, 929, DateTimeKind.Local).AddTicks(9058), new DateTime(2125, 6, 3, 16, 19, 35, 929, DateTimeKind.Local).AddTicks(9061), new DateTime(2025, 6, 3, 16, 19, 35, 929, DateTimeKind.Local).AddTicks(9060) });

            migrationBuilder.CreateIndex(
                name: "IX_Spool_CircuitListId",
                table: "Spool",
                column: "CircuitListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spool_CircuitList_CircuitListId",
                table: "Spool",
                column: "CircuitListId",
                principalTable: "CircuitList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
