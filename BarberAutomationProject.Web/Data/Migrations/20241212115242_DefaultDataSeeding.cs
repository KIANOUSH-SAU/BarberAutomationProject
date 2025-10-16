using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarberAutomationProject.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class DefaultDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aef652d9-61d6-4240-a1d7-658e592c85fc", null, "Admin", "ADMIN" },
                    { "ce7244ce-71f0-49b5-9db3-9bf987f93be1", null, "Employee", "EMPLOYEE" },
                    { "fbbf89f1-abde-4855-96e3-6c1084e2799f", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "85aa7c1d-e0ac-48b7-a71c-fbed3719020e", 0, "e3b578e3-d053-4f8a-9fd2-bbb58238a1dd", "G221210571@sakarya.edu.tr", true, false, null, "G221210571@SAKARYA.EDU.TR", "G221210571@SAKARYA.EDU.TR", "AQAAAAIAAYagAAAAEEcFyiT0z5iJxJYyWi7cvbm7ZvKYfoFe2u450bBFSv/s29jic7gmTOrr05Bp36ApqQ==", null, false, "e4f26b41-572e-453a-b136-58170f9faf4d", false, "G221210571@sakarya.edu.tr" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aef652d9-61d6-4240-a1d7-658e592c85fc", "85aa7c1d-e0ac-48b7-a71c-fbed3719020e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce7244ce-71f0-49b5-9db3-9bf987f93be1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbbf89f1-abde-4855-96e3-6c1084e2799f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aef652d9-61d6-4240-a1d7-658e592c85fc", "85aa7c1d-e0ac-48b7-a71c-fbed3719020e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aef652d9-61d6-4240-a1d7-658e592c85fc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e");
        }
    }
}
