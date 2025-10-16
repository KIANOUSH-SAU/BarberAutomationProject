using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop1._0._1.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ServicesAndBarbersRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barbers",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBarber",
                columns: table => new
                {
                    BarberId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBarber", x => new { x.BarberId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceBarber_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceBarber_Services_ServiceId",
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
                values: new object[] { "8c9dc9a5-3010-462a-816f-d50b3ed609a5", "AQAAAAIAAYagAAAAENN9SZ2+0iivEbOUmsRqZjpCCF4z04Gl5uN8fqOXHdCPxgy3CyhceVhwgIw9ScLf0A==", "a4a759c4-0951-4643-8bde-dd14e103c141" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBarber_ServiceId",
                table: "ServiceBarber",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceBarber");

            migrationBuilder.DropTable(
                name: "Barbers");

            migrationBuilder.AddColumn<string>(
                name: "Barbers",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46e0bebd-5575-4d17-afd8-b2312579c66a", "AQAAAAIAAYagAAAAEJvbRmG9aeF0zltVcqUqIlAZDiLDgShtX8/jbHcYtDzflMI1cC81OmXGdCnhsydsQw==", "cc47c87f-9377-49c4-a565-59710cb79739" });
        }
    }
}
