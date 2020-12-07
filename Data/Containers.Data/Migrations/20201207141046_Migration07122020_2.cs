using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Containers.Data.Migrations
{
    public partial class Migration07122020_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Schedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Schedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Container",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Container",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Container",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Container",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_IsDeleted",
                table: "Schedules",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Container_IsDeleted",
                table: "Container",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedules_IsDeleted",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Container_IsDeleted",
                table: "Container");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Container");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Container");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Container");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Container");
        }
    }
}
