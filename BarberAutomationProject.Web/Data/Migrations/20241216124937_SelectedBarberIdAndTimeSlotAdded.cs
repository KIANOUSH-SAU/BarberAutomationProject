using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop1._0._1.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SelectedBarberIdAndTimeSlotAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelectedBarberId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedTimeSlotId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88259879-1390-4ee2-b11f-e3282f679fc9", "AQAAAAIAAYagAAAAENoyXXUYdgtjKyrnAO1e0MXHW9JtCCQIixKpMsGxaLL0sSTgw9oWeaWP+PDxAy1Qbg==", "545dc47a-409e-4246-9421-b565d4796af9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedBarberId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SelectedTimeSlotId",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c82c40c-d673-486e-8038-012b246482f0", "AQAAAAIAAYagAAAAEP+yHQ++5l1Lrduyx97BquXImF7qidFA1Mg/SGymL5flVNolg8yr9sWlsuR1OyKLlA==", "4b14971c-1616-42eb-873d-ff21078d6c00" });
        }
    }
}
