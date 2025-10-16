using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberAutomationProject.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class BarbersScaffoldMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fde1ada2-1b3b-4948-a5a4-6540e2a8d60f", "AQAAAAIAAYagAAAAEKxFAeoyR9FWwl2jxp0MjE777mlpmKvDp5PbHhtKGQKoS03S9SQeuzoQNCgKMy5s0A==", "c96026b8-c9f1-4853-b0e2-e17292575c58" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89796f02-49a2-4e68-a295-ef4c5a2cc4d5", "AQAAAAIAAYagAAAAEAKVzBIgdJZDM/tshbm9Yor+uImvjcfJZtttxhcq3bURvD49HDxbE7zaz1yOqHnbWQ==", "7576a366-e623-4da8-b09f-255b98d62f04" });
        }
    }
}
