using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSSolution.Application.Migrations
{
    public partial class UpdateShopStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createDate",
                table: "ShopStatuses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createUser",
                table: "ShopStatuses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateDate",
                table: "ShopStatuses",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updateDate",
                table: "Shops",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "createDate",
                table: "Shops",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createDate",
                table: "ShopStatuses");

            migrationBuilder.DropColumn(
                name: "createUser",
                table: "ShopStatuses");

            migrationBuilder.DropColumn(
                name: "updateDate",
                table: "ShopStatuses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updateDate",
                table: "Shops",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createDate",
                table: "Shops",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
