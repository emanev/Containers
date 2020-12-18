using Microsoft.EntityFrameworkCore.Migrations;

namespace Containers.Data.Migrations
{
    public partial class Migration2020_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Warehouses_WarehouseId1",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_WarehouseId1",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "WarehouseFromId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "WarehouseId1",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "WarehouseToId",
                table: "Movements");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "Movements",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "Movements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "WarehouseFromId",
                table: "Movements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId1",
                table: "Movements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseToId",
                table: "Movements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movements_WarehouseId1",
                table: "Movements",
                column: "WarehouseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Warehouses_WarehouseId1",
                table: "Movements",
                column: "WarehouseId1",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
