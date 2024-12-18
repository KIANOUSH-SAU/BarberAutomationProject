using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop1._0._1.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class BarberAvailabilityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarberAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberId = table.Column<int>(type: "int", nullable: false),
                    AvailableFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarberAvailability_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fede4a5-69fd-4a0b-b7b6-6d41a3224347", "AQAAAAIAAYagAAAAECAezsdriQ8vQjB1nP28oNGkwlltf35KLxVXOPEQEb86d418Nre9YUPeOFntqnT1eA==", "5b0a412a-9cfb-47b8-804c-70ef96b6534b" });

            migrationBuilder.CreateIndex(
                name: "IX_BarberAvailability_BarberId",
                table: "BarberAvailability",
                column: "BarberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarberAvailability");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c9dc9a5-3010-462a-816f-d50b3ed609a5", "AQAAAAIAAYagAAAAENN9SZ2+0iivEbOUmsRqZjpCCF4z04Gl5uN8fqOXHdCPxgy3CyhceVhwgIw9ScLf0A==", "a4a759c4-0951-4643-8bde-dd14e103c141" });
        }
    }
}
