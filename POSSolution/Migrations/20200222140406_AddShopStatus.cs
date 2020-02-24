using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSSolution.Application.Migrations
{
    public partial class AddShopStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Shops",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "createDate",
                table: "Shops",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createUser",
                table: "Shops",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateDate",
                table: "Shops",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ShopStatuses",
                columns: table => new
                {
                    statusId = table.Column<Guid>(nullable: false),
                    statusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopStatuses", x => x.statusId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopStatuses");

            migrationBuilder.DropColumn(
                name: "createDate",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "createUser",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "updateDate",
                table: "Shops");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Shops",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
