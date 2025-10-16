using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop1._0._1.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class BarberRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14290ff1-d9c7-4f4a-9a0a-ae6426244961", "AQAAAAIAAYagAAAAEFYEpWKb2X9WfU37ScNclTnbitldlsbsPYM4MqeTn4msuQnP9VL19M5M/U/yVALf9g==", "31330496-0037-4a86-8272-f282c3c848d7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fde1ada2-1b3b-4948-a5a4-6540e2a8d60f", "AQAAAAIAAYagAAAAEKxFAeoyR9FWwl2jxp0MjE777mlpmKvDp5PbHhtKGQKoS03S9SQeuzoQNCgKMy5s0A==", "c96026b8-c9f1-4853-b0e2-e17292575c58" });
        }
    }
}
