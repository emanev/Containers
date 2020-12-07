using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Containers.Data.Migrations
{
    public partial class Migration07122020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContainerCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerCapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContainerColours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerColours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContainerMaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerMaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventarNumber = table.Column<string>(nullable: true),
                    ContainerColourId = table.Column<int>(nullable: false),
                    ContainerMaterialTypeId = table.Column<int>(nullable: false),
                    ContainerCapacityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Container_ContainerCapacities_ContainerCapacityId",
                        column: x => x.ContainerCapacityId,
                        principalTable: "ContainerCapacities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Container_ContainerColours_ContainerColourId",
                        column: x => x.ContainerColourId,
                        principalTable: "ContainerColours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Container_ContainerMaterialTypes_ContainerMaterialTypeId",
                        column: x => x.ContainerMaterialTypeId,
                        principalTable: "ContainerMaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SrsobjectIndustrials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false),
                    AddedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrsobjectIndustrials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrsobjectIndustrials_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SrsobjectIndustrials_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    AddedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    ObjectTypeId = table.Column<int>(nullable: false),
                    RaiseDate = table.Column<DateTime>(nullable: false),
                    SrsobjectId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    RaiseTimeFrom = table.Column<TimeSpan>(nullable: false),
                    RaiseTimeTo = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_ObjectTypes_ObjectTypeId",
                        column: x => x.ObjectTypeId,
                        principalTable: "ObjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_SrsobjectIndustrials_SrsobjectId",
                        column: x => x.SrsobjectId,
                        principalTable: "SrsobjectIndustrials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SrsobjectIndustrialSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SrsobjectIndustrialId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    WeekDay = table.Column<byte>(nullable: false),
                    Hour = table.Column<byte[]>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrsobjectIndustrialSchemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrsobjectIndustrialSchemas_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SrsobjectIndustrialSchemas_SrsobjectIndustrials_SrsobjectIndustrialId",
                        column: x => x.SrsobjectIndustrialId,
                        principalTable: "SrsobjectIndustrials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerId = table.Column<int>(nullable: false),
                    WarehouseToId = table.Column<int>(nullable: false),
                    WarehouseFromId = table.Column<int>(nullable: false),
                    IsLastMovement = table.Column<bool>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true),
                    WarehouseId = table.Column<int>(nullable: true),
                    WarehouseId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movements_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movements_Container_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Container",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movements_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movements_Warehouses_WarehouseId1",
                        column: x => x.WarehouseId1,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SrsobjectIndustrialContainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SrsobjectIndustrialId = table.Column<int>(nullable: false),
                    ContainerId = table.Column<int>(nullable: false),
                    MovementId = table.Column<int>(nullable: false),
                    AddedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrsobjectIndustrialContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrsobjectIndustrialContainers_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SrsobjectIndustrialContainers_Container_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Container",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SrsobjectIndustrialContainers_Movements_MovementId",
                        column: x => x.MovementId,
                        principalTable: "Movements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SrsobjectIndustrialContainers_SrsobjectIndustrials_SrsobjectIndustrialId",
                        column: x => x.SrsobjectIndustrialId,
                        principalTable: "SrsobjectIndustrials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Container_ContainerCapacityId",
                table: "Container",
                column: "ContainerCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Container_ContainerColourId",
                table: "Container",
                column: "ContainerColourId");

            migrationBuilder.CreateIndex(
                name: "IX_Container_ContainerMaterialTypeId",
                table: "Container",
                column: "ContainerMaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_AddedByUserId",
                table: "Movements",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_ContainerId",
                table: "Movements",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_WarehouseId",
                table: "Movements",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_WarehouseId1",
                table: "Movements",
                column: "WarehouseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CityId",
                table: "Schedules",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DistrictId",
                table: "Schedules",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ObjectTypeId",
                table: "Schedules",
                column: "ObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SrsobjectId",
                table: "Schedules",
                column: "SrsobjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrialContainers_AddedByUserId",
                table: "SrsobjectIndustrialContainers",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrialContainers_ContainerId",
                table: "SrsobjectIndustrialContainers",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrialContainers_MovementId",
                table: "SrsobjectIndustrialContainers",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrialContainers_SrsobjectIndustrialId",
                table: "SrsobjectIndustrialContainers",
                column: "SrsobjectIndustrialId");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrials_AddedByUserId",
                table: "SrsobjectIndustrials",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrials_DistrictId",
                table: "SrsobjectIndustrials",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrialSchemas_AddedByUserId",
                table: "SrsobjectIndustrialSchemas",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SrsobjectIndustrialSchemas_SrsobjectIndustrialId",
                table: "SrsobjectIndustrialSchemas",
                column: "SrsobjectIndustrialId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_AddedByUserId",
                table: "Warehouses",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_CityId",
                table: "Warehouses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_DistrictId",
                table: "Warehouses",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "SrsobjectIndustrialContainers");

            migrationBuilder.DropTable(
                name: "SrsobjectIndustrialSchemas");

            migrationBuilder.DropTable(
                name: "ObjectTypes");

            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "SrsobjectIndustrials");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "ContainerCapacities");

            migrationBuilder.DropTable(
                name: "ContainerColours");

            migrationBuilder.DropTable(
                name: "ContainerMaterialTypes");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
