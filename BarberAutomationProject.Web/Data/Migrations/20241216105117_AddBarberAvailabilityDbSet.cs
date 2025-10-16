using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop1._0._1.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBarberAvailabilityDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberAvailability_Barbers_BarberId",
                table: "BarberAvailability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberAvailability",
                table: "BarberAvailability");

            migrationBuilder.RenameTable(
                name: "BarberAvailability",
                newName: "BarberAvailabilities");

            migrationBuilder.RenameIndex(
                name: "IX_BarberAvailability_BarberId",
                table: "BarberAvailabilities",
                newName: "IX_BarberAvailabilities_BarberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberAvailabilities",
                table: "BarberAvailabilities",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c82c40c-d673-486e-8038-012b246482f0", "AQAAAAIAAYagAAAAEP+yHQ++5l1Lrduyx97BquXImF7qidFA1Mg/SGymL5flVNolg8yr9sWlsuR1OyKLlA==", "4b14971c-1616-42eb-873d-ff21078d6c00" });

            migrationBuilder.AddForeignKey(
                name: "FK_BarberAvailabilities_Barbers_BarberId",
                table: "BarberAvailabilities",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberAvailabilities_Barbers_BarberId",
                table: "BarberAvailabilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberAvailabilities",
                table: "BarberAvailabilities");

            migrationBuilder.RenameTable(
                name: "BarberAvailabilities",
                newName: "BarberAvailability");

            migrationBuilder.RenameIndex(
                name: "IX_BarberAvailabilities_BarberId",
                table: "BarberAvailability",
                newName: "IX_BarberAvailability_BarberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberAvailability",
                table: "BarberAvailability",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fede4a5-69fd-4a0b-b7b6-6d41a3224347", "AQAAAAIAAYagAAAAECAezsdriQ8vQjB1nP28oNGkwlltf35KLxVXOPEQEb86d418Nre9YUPeOFntqnT1eA==", "5b0a412a-9cfb-47b8-804c-70ef96b6534b" });

            migrationBuilder.AddForeignKey(
                name: "FK_BarberAvailability_Barbers_BarberId",
                table: "BarberAvailability",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
