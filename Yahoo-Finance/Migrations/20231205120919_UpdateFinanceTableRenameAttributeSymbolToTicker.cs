using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yahoo_Finance.Migrations
{
    public partial class UpdateFinanceTableRenameAttributeSymbolToTicker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Finances",
                newName: "Ticker");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ticker",
                table: "Finances",
                newName: "Symbol");
        }
    }
}
