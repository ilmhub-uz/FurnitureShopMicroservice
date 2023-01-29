using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contract.Api.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.AddColumn<long>(
                name: "Count",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Contracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
