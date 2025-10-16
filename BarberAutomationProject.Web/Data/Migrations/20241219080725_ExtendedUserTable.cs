using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberAutomationProject.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89796f02-49a2-4e68-a295-ef4c5a2cc4d5", "Default", "Admin", "AQAAAAIAAYagAAAAEAKVzBIgdJZDM/tshbm9Yor+uImvjcfJZtttxhcq3bURvD49HDxbE7zaz1yOqHnbWQ==", "7576a366-e623-4da8-b09f-255b98d62f04" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88259879-1390-4ee2-b11f-e3282f679fc9", "AQAAAAIAAYagAAAAENoyXXUYdgtjKyrnAO1e0MXHW9JtCCQIixKpMsGxaLL0sSTgw9oWeaWP+PDxAy1Qbg==", "545dc47a-409e-4246-9421-b565d4796af9" });
        }
    }
}
