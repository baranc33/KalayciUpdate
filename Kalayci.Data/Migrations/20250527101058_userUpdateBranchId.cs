using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class userUpdateBranchId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_BranchId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_BranchId",
                table: "AspNetUsers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_BranchId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_BranchId",
                table: "AspNetUsers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
