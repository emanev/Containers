using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Containers.Data.Migrations
{
    public partial class Migration10122020_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Warehouses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Warehouses",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Warehouses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Warehouses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "SrsobjectIndustrialSchemas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SrsobjectIndustrialSchemas",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SrsobjectIndustrialSchemas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "SrsobjectIndustrialSchemas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "SrsobjectIndustrials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SrsobjectIndustrials",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SrsobjectIndustrials",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "SrsobjectIndustrials",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "SrsobjectIndustrialContainers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SrsobjectIndustrialContainers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SrsobjectIndustrialContainers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "SrsobjectIndustrialContainers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseFromId",
                table: "Movements",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_IsDeleted",
                table: "Warehouses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrialSchemas_IsDeleted",
                table: "SrsobjectIndustrialSchemas",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrials_IsDeleted",
                table: "SrsobjectIndustrials",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrialContainers_IsDeleted",
                table: "SrsobjectIndustrialContainers",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Warehouses_IsDeleted",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_SrsobjectIndustrialSchemas_IsDeleted",
                table: "SrsobjectIndustrialSchemas");

            migrationBuilder.DropIndex(
                name: "IX_SrsobjectIndustrials_IsDeleted",
                table: "SrsobjectIndustrials");

            migrationBuilder.DropIndex(
                name: "IX_SrsobjectIndustrialContainers_IsDeleted",
                table: "SrsobjectIndustrialContainers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "SrsobjectIndustrialSchemas");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SrsobjectIndustrialSchemas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SrsobjectIndustrialSchemas");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "SrsobjectIndustrialSchemas");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "SrsobjectIndustrials");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SrsobjectIndustrials");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SrsobjectIndustrials");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "SrsobjectIndustrials");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "SrsobjectIndustrialContainers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SrsobjectIndustrialContainers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SrsobjectIndustrialContainers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "SrsobjectIndustrialContainers");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseFromId",
                table: "Movements",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ContainerColours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ContainerColours",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ContainerColours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ContainerColours",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ContainerCapacities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ContainerCapacities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ContainerCapacities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ContainerCapacities",
                type: "datetime2",
                nullable: true);
        }
    }
}
