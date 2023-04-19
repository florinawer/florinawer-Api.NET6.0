using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingDDD.Infrastructure.Persistence.Migrations
{
    public partial class _03Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_Stocks_StockId",
                table: "Portfolio");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "Portfolio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_Stocks_StockId",
                table: "Portfolio",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_Stocks_StockId",
                table: "Portfolio");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "Portfolio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_Stocks_StockId",
                table: "Portfolio",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
