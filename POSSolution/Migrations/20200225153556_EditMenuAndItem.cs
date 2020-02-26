using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSSolution.Application.Migrations
{
    public partial class EditMenuAndItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_Regions_regionId",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Table",
                table: "Table");

            migrationBuilder.RenameTable(
                name: "Table",
                newName: "Tables");

            migrationBuilder.RenameIndex(
                name: "IX_Table_regionId",
                table: "Tables",
                newName: "IX_Tables_regionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "tableId");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(nullable: true),
                    itemCode = table.Column<string>(nullable: true),
                    itemImage = table.Column<string>(nullable: true),
                    itemPrice = table.Column<decimal>(nullable: true),
                    createUser = table.Column<string>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    menuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    createUser = table.Column<string>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.menuId);
                });

            migrationBuilder.CreateTable(
                name: "TableStatuses",
                columns: table => new
                {
                    statusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusName = table.Column<string>(nullable: true),
                    createUser = table.Column<string>(nullable: true),
                    regionsregionId = table.Column<Guid>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableStatuses", x => x.statusId);
                    table.ForeignKey(
                        name: "FK_TableStatuses_Regions_regionsregionId",
                        column: x => x.regionsregionId,
                        principalTable: "Regions",
                        principalColumn: "regionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    menuId = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => new { x.menuId, x.itemId });
                    table.ForeignKey(
                        name: "FK_MenuItems_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_menuId",
                        column: x => x.menuId,
                        principalTable: "Menus",
                        principalColumn: "menuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_itemId",
                table: "MenuItems",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_TableStatuses_regionsregionId",
                table: "TableStatuses",
                column: "regionsregionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Regions_regionId",
                table: "Tables",
                column: "regionId",
                principalTable: "Regions",
                principalColumn: "regionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Regions_regionId",
                table: "Tables");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "TableStatuses");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "Table");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_regionId",
                table: "Table",
                newName: "IX_Table_regionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table",
                table: "Table",
                column: "tableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Regions_regionId",
                table: "Table",
                column: "regionId",
                principalTable: "Regions",
                principalColumn: "regionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
