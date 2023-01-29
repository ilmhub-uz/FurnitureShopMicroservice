using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contract.Api.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Contracts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductCount",
                table: "Contracts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Contracts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
