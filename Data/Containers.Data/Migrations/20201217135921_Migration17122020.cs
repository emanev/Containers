using Microsoft.EntityFrameworkCore.Migrations;

namespace Containers.Data.Migrations
{
    public partial class Migration17122020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Cities_CityId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Cities_CityId",
                table: "Warehouses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_CityId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_CityId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Schedules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movements_WarehouseId",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_WarehouseId1",
                table: "Movements");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Warehouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_CityId",
                table: "Warehouses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CityId",
                table: "Schedules",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Cities_CityId",
                table: "Schedules",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Cities_CityId",
                table: "Warehouses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
