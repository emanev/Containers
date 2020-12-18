using Microsoft.EntityFrameworkCore.Migrations;

namespace Containers.Data.Migrations
{
    public partial class Migration2020_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //   name: "FK_Movements_Warehouses_WarehouseId",
            //   table: "Movements");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Movements_Warehouses_WarehouseId1",
            //    table: "Movements");

            //migrationBuilder.DropIndex(
            //    name: "IX_Movements_WarehouseId",
            //    table: "Movements");

            //migrationBuilder.DropIndex(
            //    name: "IX_Movements_WarehouseId1",
            //    table: "Movements");

            //migrationBuilder.DropColumn(
            //    name: "WarehouseId",
            //    table: "Movements");

            //migrationBuilder.DropColumn(
            //    name: "WarehouseId1",
            //    table: "Movements");

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



            //migrationBuilder.DropForeignKey(
            //    name: "FK_Movements_Warehouses_WarehouseFromId",
            //    table: "Movements");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Movements_Warehouses_WarehouseToId",
            //    table: "Movements");

            //migrationBuilder.DropIndex(
            //    name: "IX_Movements_WarehouseFromId",
            //    table: "Movements");

            //migrationBuilder.DropIndex(
            //    name: "IX_Movements_WarehouseToId",
            //    table: "Movements");

            //migrationBuilder.AddColumn<int>(
            //    name: "WarehouseId",
            //    table: "Movements",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "WarehouseId1",
            //    table: "Movements",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Movements_WarehouseId",
            //    table: "Movements",
            //    column: "WarehouseId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Movements_WarehouseId1",
            //    table: "Movements",
            //    column: "WarehouseId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Movements_Warehouses_WarehouseId",
            //    table: "Movements",
            //    column: "WarehouseId",
            //    principalTable: "Warehouses",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Movements_Warehouses_WarehouseId1",
            //    table: "Movements",
            //    column: "WarehouseId1",
            //    principalTable: "Warehouses",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
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
