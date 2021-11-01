using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.Infrastructure.EFCore.Migrations
{
    public partial class initialStockCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "StockCount",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "StockId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Products");
        }
    }
}
