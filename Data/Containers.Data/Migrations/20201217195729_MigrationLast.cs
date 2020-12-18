using Microsoft.EntityFrameworkCore.Migrations;

namespace Containers.Data.Migrations
{
    public partial class MigrationLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_Movements_WarehouseFromId",
                table: "Movements",
                column: "WarehouseFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_WarehouseToId",
                table: "Movements",
                column: "WarehouseToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Warehouses_WarehouseFromId",
                table: "Movements",
                column: "WarehouseFromId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Warehouses_WarehouseToId",
                table: "Movements",
                column: "WarehouseToId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Warehouses_WarehouseId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Warehouses_WarehouseId1",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_WarehouseId",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_WarehouseId1",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "WarehouseId1",
                table: "Movements");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_WarehouseFromId",
                table: "Movements",
                column: "WarehouseFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_WarehouseToId",
                table: "Movements",
                column: "WarehouseToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Warehouses_WarehouseFromId",
                table: "Movements",
                column: "WarehouseFromId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Warehouses_WarehouseToId",
                table: "Movements",
                column: "WarehouseToId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
