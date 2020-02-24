using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSSolution.Application.Migrations
{
    public partial class ShopManage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    shopId = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.shopId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    regionId = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    shopId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.regionId);
                    table.ForeignKey(
                        name: "FK_Regions_Shops_shopId",
                        column: x => x.shopId,
                        principalTable: "Shops",
                        principalColumn: "shopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_shopId",
                table: "Regions",
                column: "shopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
