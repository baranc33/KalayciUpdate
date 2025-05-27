using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class secondary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "personelId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 9, 17, 16, 719, DateTimeKind.Local).AddTicks(8931), new DateTime(2025, 5, 27, 9, 17, 16, 719, DateTimeKind.Local).AddTicks(8930) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_personelId",
                table: "AspNetUsers",
                column: "personelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Personel_personelId",
                table: "AspNetUsers",
                column: "personelId",
                principalTable: "Personel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Personel_personelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_personelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "personelId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 22, 0, 43, 654, DateTimeKind.Local).AddTicks(6219), new DateTime(2025, 5, 26, 22, 0, 43, 654, DateTimeKind.Local).AddTicks(6218) });
        }
    }
}
