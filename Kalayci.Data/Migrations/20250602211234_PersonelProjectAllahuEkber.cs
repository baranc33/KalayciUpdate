using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalayci.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonelProjectAllahuEkber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonelProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    IsActiveWork = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ManagerName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
