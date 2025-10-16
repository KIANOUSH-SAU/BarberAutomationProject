using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberAutomationProject.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class BarbersColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barbers",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46e0bebd-5575-4d17-afd8-b2312579c66a", "AQAAAAIAAYagAAAAEJvbRmG9aeF0zltVcqUqIlAZDiLDgShtX8/jbHcYtDzflMI1cC81OmXGdCnhsydsQw==", "cc47c87f-9377-49c4-a565-59710cb79739" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barbers",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75c1993a-6084-4409-a6f5-e155e115b714", "AQAAAAIAAYagAAAAECR5Zaw0dPuK4pnfizg88dWnwB9YrcAqcDQ7r8qaRYj5r8nsiSTXA5ccpOC6wyHlaw==", "d8d52f65-6569-4784-b55e-0a55b33aaae4" });
        }
    }
}
