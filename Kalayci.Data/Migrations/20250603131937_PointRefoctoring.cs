using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class PointRefoctoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserGivePoint",
                table: "Point",
                newName: "UserNameGivePoint");

            migrationBuilder.RenameColumn(
                name: "SavePoint",
                table: "Point",
                newName: "TeamWorkPoint");

            migrationBuilder.AddColumn<byte>(
                name: "AveragePoint",
                table: "Point",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ContinuityPoint",
                table: "Point",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "JabTrackingPoint",
                table: "Point",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AveragePoint",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "ContinuityPoint",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "JabTrackingPoint",
                table: "Point");

            migrationBuilder.RenameColumn(
                name: "UserNameGivePoint",
                table: "Point",
                newName: "UserGivePoint");

            migrationBuilder.RenameColumn(
                name: "TeamWorkPoint",
                table: "Point",
                newName: "SavePoint");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b87ded05-d695-4b98-a74f-b7d1743b5466");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e926b228-8bbf-49fd-9fb6-cabb7d86e3f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "fbeab674-558e-4d04-a454-9a0d3fa8da44");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "32bace6d-732a-419f-8fe0-424e2a33e7af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "85468d4d-dda1-408e-a095-056a01c58cdf");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 0, 12, 33, 587, DateTimeKind.Local).AddTicks(47), new DateTime(2025, 6, 3, 0, 12, 33, 587, DateTimeKind.Local).AddTicks(46) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 0, 12, 33, 587, DateTimeKind.Local).AddTicks(55), new DateTime(2025, 6, 3, 0, 12, 33, 587, DateTimeKind.Local).AddTicks(54) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 6, 3, 0, 12, 33, 590, DateTimeKind.Local).AddTicks(7529), new DateTime(2025, 6, 3, 0, 12, 33, 590, DateTimeKind.Local).AddTicks(7532), new DateTime(2125, 6, 3, 0, 12, 33, 590, DateTimeKind.Local).AddTicks(7534), new DateTime(2025, 6, 3, 0, 12, 33, 590, DateTimeKind.Local).AddTicks(7533) });
        }
    }
}
