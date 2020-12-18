using Microsoft.EntityFrameworkCore.Migrations;

namespace Containers.Data.Migrations
{
    public partial class Migration18122020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_SrsobjectIndustrials",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_SrsobjectId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "SrsobjectId",
                table: "Schedules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SrsobjectId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SrsobjectId",
                table: "Schedules",
                column: "SrsobjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_SrsobjectIndustrials",
                table: "Schedules",
                column: "SrsobjectId",
                principalTable: "SrsobjectIndustrials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
