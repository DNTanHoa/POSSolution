using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSSolution.Application.Migrations
{
    public partial class AddMenuAndItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "Regions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createDate",
                table: "Regions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createUser",
                table: "Regions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateDate",
                table: "Regions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    tableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tableName = table.Column<string>(nullable: true),
                    tableCode = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    currentPeople = table.Column<int>(nullable: false),
                    regionId = table.Column<Guid>(nullable: true),
                    createUser = table.Column<string>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.tableId);
                    table.ForeignKey(
                        name: "FK_Table_Regions_regionId",
                        column: x => x.regionId,
                        principalTable: "Regions",
                        principalColumn: "regionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Table_regionId",
                table: "Table",
                column: "regionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropColumn(
                name: "code",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "createDate",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "createUser",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "updateDate",
                table: "Regions");
        }
    }
}
