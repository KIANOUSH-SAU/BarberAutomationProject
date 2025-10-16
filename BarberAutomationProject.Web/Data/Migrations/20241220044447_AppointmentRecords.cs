using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberAutomationProject.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentRecords_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentRecords_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a75db91-06d4-4632-a601-b4ee2edd4903", "AQAAAAIAAYagAAAAEHXwYFGWuCOGL6Skwk9WdQhLbntROXdWDICpM+ObwR51pelUASZeIW8OZCt0QSJOtA==", "e3c5602d-1923-4c4d-b9cc-ea83ed7a9df1" });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentRecords_BarberId",
                table: "AppointmentRecords",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentRecords_ServiceId",
                table: "AppointmentRecords",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentRecords");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14290ff1-d9c7-4f4a-9a0a-ae6426244961", "AQAAAAIAAYagAAAAEFYEpWKb2X9WfU37ScNclTnbitldlsbsPYM4MqeTn4msuQnP9VL19M5M/U/yVALf9g==", "31330496-0037-4a86-8272-f282c3c848d7" });
        }
    }
}
