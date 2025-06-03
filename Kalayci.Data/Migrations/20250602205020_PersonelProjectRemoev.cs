using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonelProjectRemoev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelProjects");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8531bdfa-0f38-4170-aa27-9b5a110d2227");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4289572b-033b-4836-946f-f635345a57c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f3b3a690-d647-497e-91bd-19b00d67a77d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "c6438806-08de-4084-9973-46afd159482c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "b671c7dd-2dcc-4082-a6b8-1e8ff353341d");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 23, 50, 20, 180, DateTimeKind.Local).AddTicks(2290), new DateTime(2025, 6, 2, 23, 50, 20, 180, DateTimeKind.Local).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 23, 50, 20, 180, DateTimeKind.Local).AddTicks(2294), new DateTime(2025, 6, 2, 23, 50, 20, 180, DateTimeKind.Local).AddTicks(2294) });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "WorkFinishDate", "WorkStartDate" },
                values: new object[] { new DateTime(2025, 6, 2, 23, 50, 20, 184, DateTimeKind.Local).AddTicks(234), new DateTime(2025, 6, 2, 23, 50, 20, 184, DateTimeKind.Local).AddTicks(238), new DateTime(2125, 6, 2, 23, 50, 20, 184, DateTimeKind.Local).AddTicks(241), new DateTime(2025, 6, 2, 23, 50, 20, 184, DateTimeKind.Local).AddTicks(240) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonelProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    CreatedByName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsActiveWork = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ManagerName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedByName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelProjects_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelProjects_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelProjects_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "IX_PersonelProjects_BranchId",
                table: "PersonelProjects",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelProjects_PersonelId",
                table: "PersonelProjects",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelProjects_ProjectId",
                table: "PersonelProjects",
                column: "ProjectId");
        }
    }
}
